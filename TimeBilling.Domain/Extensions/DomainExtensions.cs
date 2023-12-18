//namespace TimeBilling.Domain.Extensions;
namespace Microsoft.Extensions.DependencyInjection;

using TimeBilling.Domain.Mediators;

public static class DomainExtensions
{
    public static IServiceCollection AddDomainRegistrations(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DomainExtensions).Assembly);

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblyContaining(typeof(CustomerCommandMediator));
        });

        return services;
    }
}
