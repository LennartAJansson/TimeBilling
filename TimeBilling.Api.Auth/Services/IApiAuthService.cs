namespace TimeBilling.Api.Auth.Services;

using TimeBilling.Api.Auth.Contracts;
using TimeBilling.Api.Auth.Data.Model;

public interface IApiAuthService
{
  Task<AuthUser> Register(string email, string password, string confirmPassword);
  Task<AuthUser> AcknowledgeRegistration(string email);
  Task<AuthLogin> Login(string email, string password);
  Task<AuthUser> Logout(string email);
  Task<AuthRole> CreateRole(string roleName);
  Task<AuthRole> DeleteRole(string roleName);
  Task<AuthRole> AssignRole(string email, string roleName);
  Task<AuthRole> RevokeRole(string email, string roleName);
  string Base64UrlEncode(string base64EncodedData);
}