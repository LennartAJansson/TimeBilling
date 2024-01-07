namespace TimeBilling.Api.Auth.Data.Context;

using System.Data;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using TimeBilling.Api.Auth.Data.Model;

internal sealed class ApiAuthDbContext(DbContextOptions<ApiAuthDbContext> options)
  : IdentityDbContext<AuthUser, AuthRole, Guid>(options)
{
  public void EnsureDbExists()
  {
    IEnumerable<string> migrations = Database.GetPendingMigrations();
    if (migrations.Any())
    {
      Database.Migrate();
    }
    EnsureBaseRolesExists();
  }

  private void EnsureBaseRolesExists()
  {
    bool needsToSave = false;
    if (!Roles.Where(r => r.Name == "User").Any())
    {
      _ = Roles.Add(new AuthRole { Id = Guid.NewGuid(), Name = "User", NormalizedName = "USER", ConcurrencyStamp = Guid.NewGuid().ToString() });
      needsToSave = true;
    }

    if (!Roles.Where(r => r.Name == "Admin").Any())
    {
      _ = Roles.Add(new AuthRole { Id = Guid.NewGuid(), Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() });
      needsToSave = true;
    }

    if (!Roles.Where(r => r.Name == "SuperAdmin").Any())
    {
      _ = Roles.Add(new AuthRole { Id = Guid.NewGuid(), Name = "SuperAdmin", NormalizedName = "SUPERADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() });
      needsToSave = true;
    }

    //if (!Users.Where(r => r.Email == "sa@local").Any())
    //{
    //  _ = Users.Add(new AuthUser
    //  {
    //    Id = Guid.NewGuid(),
    //    UserName = "sa@local",
    //    NormalizedUserName = "SA@LOCAL",
    //    Email = "sa@local",
    //    NormalizedEmail = "SA@LOCAL",
    //    EmailConfirmed = true,
    //    AccessFailedCount = 0,
    //    LockoutEnabled = false,
    //    SecurityStamp = Guid.NewGuid().ToString(),
    //    LockoutEnd = null,
    //    PhoneNumber = null,
    //    PhoneNumberConfirmed = true,
    //    TwoFactorEnabled = false,
    //    ConcurrencyStamp = Guid.NewGuid().ToString()
    //  });

    if (needsToSave)
    {
      _ = SaveChanges();
    }
  }
}
