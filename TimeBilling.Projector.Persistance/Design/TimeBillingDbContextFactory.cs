namespace TimeBilling.Projector.Persistance.Design;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using TimeBilling.Projector.Persistance.Context;

/*
Add-Migration Initial -Context TimeBillingDbContext -Project TimeBilling.Projector.Persistance -StartupProject TimeBilling.Projector.Persistance 
Update-Database -Context TimeBillingDbContext -Project TimeBilling.Projector.Persistance -StartupProject TimeBilling.Projector.Persistance
*/

internal sealed class TimeBillingDbContextFactory : IDesignTimeDbContextFactory<TimeBillingDbContext>
{
  public TimeBillingDbContext CreateDbContext(string[] args)
  {
    IConfiguration configuration = new ConfigurationBuilder()
        .AddUserSecrets<TimeBillingDbContext>()
        .Build();

    string? connectionString = configuration.GetConnectionString("TimeBillingDb")
      ?? throw new ArgumentException("No connectionstring");

    ServerVersion serverVersion = ServerVersion.AutoDetect(connectionString);
    DbContextOptionsBuilder<TimeBillingDbContext> optionsBuilder = new();
    _ = optionsBuilder.UseMySql(connectionString, serverVersion)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();

    return new TimeBillingDbContext(optionsBuilder.Options);
  }
}
