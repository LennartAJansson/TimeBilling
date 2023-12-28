namespace TimeBilling.Api.Domain.Extensions;

using Microsoft.Extensions.DependencyInjection;

using TimeBilling.Api.Domain.Abstract.Handlers;
using TimeBilling.Api.Domain.Handlers;

public static class ApiExtensions
{
  public static IServiceCollection AddApiDomainRegistrations(this IServiceCollection services)
  {
    _ = services.AddAutoMapper(typeof(ApiExtensions).Assembly);
    _ = services.AddMediatR(configuration =>
      {
        _ = configuration.RegisterServicesFromAssembly(typeof(ApiExtensions).Assembly);
      });
    _ = services.AddTransient<ICustomersHandler, CustomersHandler>();
    _ = services.AddTransient<IPeopleHandler, PeopleHandler>();
    _ = services.AddTransient<IWorkloadsHandler, WorkloadsHandler>();

    return services;
  }
}
