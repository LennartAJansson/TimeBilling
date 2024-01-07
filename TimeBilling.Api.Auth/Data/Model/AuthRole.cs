namespace TimeBilling.Api.Auth.Data.Model;

using Microsoft.AspNetCore.Identity;

public class AuthRole : IdentityRole<Guid>
{

  public ICollection<AuthUser> Users { get; set; } = new HashSet<AuthUser>();
}
