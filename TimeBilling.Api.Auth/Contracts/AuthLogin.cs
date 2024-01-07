namespace TimeBilling.Api.Auth.Contracts;

public class AuthLogin(Guid id, string? userName, IEnumerable<string> roles, string jwt)
{
  public Guid Id { get; set; } = id;
  public string? UserName { get; set; } = userName;
  public IEnumerable<string> Roles { get; set; } = roles;
  public string Jwt { get; set; } = jwt;
}
