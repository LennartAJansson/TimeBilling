using Microsoft.Extensions.DependencyInjection;

namespace TimeBilling.Persistance.Extensions;

using Microsoft.EntityFrameworkCore;

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
}
