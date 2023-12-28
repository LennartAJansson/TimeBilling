namespace TimeBilling.Api.Persistance.Extensions;
using Microsoft.Extensions.DependencyInjection;

using TimeBilling.Api.Persistance.Services;
using TimeBilling.Api.Domain.Abstract.Services;

public static class QueryExtensions
{
  public static IServiceCollection AddApiPersistanceRegistrations(this IServiceCollection services)
  {
    _ = services.AddTransient<ITimeBillingQueryService, TimeBillingQueryService>();

    return services;
  }
}
