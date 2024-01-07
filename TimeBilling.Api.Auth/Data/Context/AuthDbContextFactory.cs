namespace TimeBilling.Api.Auth.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

/*
Add-Migration Initial -Context ApiAuthDbContext -Project TimeBilling.Api.Auth -StartupProject TimeBilling.Api.Auth 
Update-Database -Context ApiAuthDbContext -Project TimeBilling.Api.Auth -StartupProject TimeBilling.Api.Auth
*/

internal sealed class AuthDbContextFactory : IDesignTimeDbContextFactory<ApiAuthDbContext>
{
  public ApiAuthDbContext CreateDbContext(string[] args)
  {
    IConfiguration configuration = new ConfigurationBuilder()
        .AddUserSecrets<ApiAuthDbContext>()
        .Build();

    string? connectionString = configuration.GetConnectionString("AuthDb")
      ?? throw new ArgumentException("No connectionstring");

    ServerVersion serverVersion = ServerVersion.AutoDetect(connectionString);
    DbContextOptionsBuilder<ApiAuthDbContext> optionsBuilder = new();
    _ = optionsBuilder.UseMySql(connectionString, serverVersion)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();

    return new ApiAuthDbContext(optionsBuilder.Options);
  }
}
