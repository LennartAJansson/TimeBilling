namespace TimeBilling.Api.Extensions;

using TimeBilling.Api.Handlers;
using TimeBilling.Domain.Abstract.Handlers;

public static class ApiHandlersExtension
{
    public static IServiceCollection AddApiHandlers(this IServiceCollection services)
    {
        services.AddTransient<ICustomerHandlers, CustomerHandlers>();

        return services;
    }
}
