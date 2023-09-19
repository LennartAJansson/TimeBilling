namespace TimeBilling.Persistance.Design;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using TimeBilling.Persistance.Context;

/*
Add-Migration Initial -Context TimeBillingDbContext -Project TimeBilling.Persistance -StartupProject TimeBilling.Persistance 
Update-Database -Context TimeBillingDbContext -Project TimeBilling.Persistance -StartupProject TimeBilling.Persistance
*/

internal sealed class TimeBillingDbContextFactory : IDesignTimeDbContextFactory<TimeBillingDbContext>
{
    public TimeBillingDbContext CreateDbContext(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddUserSecrets<TimeBillingDbContext>()
            .Build();

        DbContextOptionsBuilder<TimeBillingDbContext> optionsBuilder = new();
        _ = optionsBuilder.UseSqlServer(configuration.GetConnectionString("TimeBillingDb")
            ?? throw new ArgumentException("No connectionstring"))
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();

        return new TimeBillingDbContext(optionsBuilder.Options);
    }
}
