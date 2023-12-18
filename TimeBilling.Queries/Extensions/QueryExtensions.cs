namespace TimeBilling.Queries.Extensions;
using Microsoft.Extensions.DependencyInjection;

using TimeBilling.Domain.Abstract.Services;
using TimeBilling.Queries.Services;

public static class QueryExtensions
{
  public static IServiceCollection AddQueriesRegistrations(this IServiceCollection services)
  {
    _ = services.AddTransient<ITimeBillingQueryService, TimeBillingQueryService>();

    return services;
  }
}
