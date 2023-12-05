namespace TimeBilling.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using TimeBilling.Domain.Abstract.Services;
using TimeBilling.Persistance.Context;
using TimeBilling.Persistance.Services;

public static class PersistanceExtensions
{
  public static IServiceCollection AddPersistanceRegistrations(this IServiceCollection services, string connectionString)
  {
    _ = services.AddDbContext<ITimeBillingDbContext, TimeBillingDbContext>(builder =>
    {
      ServerVersion serverVersion = ServerVersion.AutoDetect(connectionString);
      _ = builder.UseMySql(connectionString, serverVersion);

    });
    _ = services.AddTransient<ITimeBillingService, TimeBillingService>();

    return services;
  }

  public static IHost ConfigurePersistance(this IHost app)
  {
    using IServiceScope scope = app.Services.CreateScope();
    _ = scope.ServiceProvider.GetRequiredService<TimeBillingDbContext>().EnsureDbExists();

    return app;
  }
}
