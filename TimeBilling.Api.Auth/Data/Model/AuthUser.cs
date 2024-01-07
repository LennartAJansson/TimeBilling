namespace TimeBilling.Api.Auth.Data.Model;

using Microsoft.AspNetCore.Identity;

public class AuthUser : IdentityUser<Guid>
{
  public ICollection<AuthRole> Roles { get; set; } = new HashSet<AuthRole>();
}
