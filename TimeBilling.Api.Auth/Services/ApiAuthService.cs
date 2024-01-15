namespace TimeBilling.Api.Auth.Services;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using TimeBilling.Api.Auth.Contracts;
using TimeBilling.Api.Auth.Data.Model;

public sealed class ApiAuthService(RoleManager<AuthRole> roles, UserManager<AuthUser> users, SignInManager<AuthUser> signIn, IOptions<JwtSettings> options)
  : IApiAuthService
{
  public async Task<AuthUser> Register(string email, string password, string confirmPassword)
  {
    AuthUser user = new() { UserName = email, Email = email, EmailConfirmed = true, PhoneNumberConfirmed = true };

    IdentityResult result = await users.CreateAsync(user, password);

    if (!result.Succeeded)
    {
      throw new Exception(result.Errors.First().Description);
    }

    result = await users.AddToRoleAsync(user, "User");
    if (!result.Succeeded)
    {
      throw new Exception(result.Errors.First().Description);
    }

    if (users.Users.Count() == 1)
    {
      result = await users.AddToRolesAsync(user, new string[] { "SuperAdmin", "Admin" });
    }

    return !result.Succeeded ? throw new Exception(result.Errors.First().Description) : user;
  }

  public Task<AuthUser> AcknowledgeRegistration(string email) => throw new NotImplementedException();

  public async Task<AuthLogin> Login(string email, string password)
  {
    AuthUser? user = await users.FindByEmailAsync(email);
    if (user is null || !user.EmailConfirmed || !user.PhoneNumberConfirmed)
    {
      throw new Exception("User not found or confirmed");
    }

    IEnumerable<string> roles = await users.GetRolesAsync(user);

    user.PhoneNumberConfirmed = true;
    user.EmailConfirmed = true;

    bool userSigninResult = await users.CheckPasswordAsync(user, password);
    if (!userSigninResult)
    {
      throw new Exception("User not logged in");
    }

    string jwt = GenerateJwt(user, roles);

    //await signIn.SignInAsync(user, false);

    return new AuthLogin(user.Id, user.UserName, roles, jwt);
  }

  public async Task<AuthUser> Logout(string email)
  {
    AuthUser? user = await users.FindByEmailAsync(email);
    if (user is null)
    {
      throw new Exception("User not found");
    }

    //await signIn.SignOutAsync();

    return user;
  }

  public async Task<AuthRole> CreateRole(string roleName)
  {
    AuthRole? role = await roles.FindByNameAsync(roleName);
    if (role is not null)
    {
      throw new Exception("Role already exists");
    }

    role = new() { Name = roleName };
    IdentityResult result = await roles.CreateAsync(role);

    return !result.Succeeded ? throw new Exception(result.Errors.First().Description) : role;
  }

  public async Task<AuthRole> DeleteRole(string roleName)
  {
    AuthRole? role = await roles.FindByNameAsync(roleName);
    if (role is null)
    {
      throw new Exception("Role not found");
    }
    IdentityResult result = await roles.DeleteAsync(role);

    return !result.Succeeded ? throw new Exception(result.Errors.First().Description) : role;
  }

  public async Task<AuthRole> AssignRole(string email, string roleName)
  {
    AuthUser? user = await users.FindByEmailAsync(email);
    if (user is null || !user.EmailConfirmed || !user.PhoneNumberConfirmed)
    {
      throw new Exception("User not found or confirmed");
    }

    AuthRole? role = await roles.FindByNameAsync(roleName);
    if (role is null || role.Name is null)
    {
      throw new Exception("Role not found");
    }

    if (await users.IsInRoleAsync(user, roleName))
    {
      throw new Exception($"User is already in role {roleName}");
    }

    IdentityResult result = await users.AddToRoleAsync(user, role.Name);

    return !result.Succeeded ? throw new Exception(result.Errors.First().Description) : role;
  }

  public async Task<AuthRole> RevokeRole(string email, string roleName)
  {
    AuthUser? user = await users.FindByEmailAsync(email);
    if (user is null || !user.EmailConfirmed || !user.PhoneNumberConfirmed)
    {
      throw new Exception("User not found or confirmed");
    }

    AuthRole? role = await roles.FindByNameAsync(roleName);

    if (role is null || role.Name is null)
    {
      throw new Exception("Role not found");
    }

    if (await users.IsInRoleAsync(user, roleName) is false)
    {
      throw new Exception($"User is not in role {roleName}");
    }

    IdentityResult result = await users.RemoveFromRoleAsync(user, role.Name);

    return !result.Succeeded ? throw new Exception(result.Errors.First().Description) : role;
  }

  public string Base64UrlEncode(string base64EncodedData) => Convert.ToBase64String(Encoding.UTF8.GetBytes(base64EncodedData)).TrimEnd('=').Replace('+', '-').Replace('/', '_');

  private string GenerateJwt(AuthUser user, IEnumerable<string> roles)
  {
    List<Claim> claims =
    [
      new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
      new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
      new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
    ];

    if (user.UserName is not null)
    {
      claims.Add(new Claim(ClaimTypes.Name, user.UserName));
    }

    if (user.Email is not null)
    {
      claims.Add(new Claim(ClaimTypes.Email, user.Email));
    }

    if (user.PhoneNumber is not null)
    {
      claims.Add(new Claim(ClaimTypes.HomePhone, user.PhoneNumber));
    }

    IEnumerable<Claim> roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));
    claims.AddRange(roleClaims);

    SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(options.Value.Secret));
    SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha256);
    DateTime expires = DateTime.Now.AddDays(Convert.ToDouble(options.Value.ExpirationInDays));

    JwtSecurityToken token = new(
        issuer: options.Value.Issuer,
        audience: options.Value.Issuer,
        claims: claims,
        expires: expires,
        signingCredentials: creds
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}

