using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using TimeBilling.Domain.Abstract.Services;
using TimeBilling.Persistance.Context;

using TimeBilling.Persistance.Services;

public static class TestHelper
{
  public static IServiceProvider GetServiceProvider() => new ServiceCollection()
      .AddLogging(builder => builder.SetMinimumLevel(LogLevel.Trace))

      //.AddPersistanceRegistrations()
      .AddDbContext<ITimeBillingDbContext, TimeBillingDbContext>(builder =>
      {
        string connectionString = "Server=localhost;Port=3306;User=root;Password=password;Database=TimeBillingDb";
        ServerVersion serverVersion = ServerVersion.AutoDetect(connectionString);
        _ = builder.UseMySql(connectionString, serverVersion);

        DbContextOptions<TimeBillingDbContext>? options = builder.Options as DbContextOptions<TimeBillingDbContext>;
        using TimeBillingDbContext ctx = new(options!);
        ctx.Database.Migrate();
      })
      .AddTransient<ITimeBillingService, TimeBillingService>()

      .BuildServiceProvider();
}