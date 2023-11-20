namespace Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;
using TimeBilling.Domain.Abstract.Services;
using TimeBilling.Persistance.Context;
using TimeBilling.Persistance.Services;

public static class PersistanceExtensions
{
    public static IServiceCollection AddPersistanceRegistrations(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ITimeBillingDbContext, TimeBillingDbContext>(builder =>
        {
            builder.UseSqlServer(connectionString);
       
        });
        services.AddTransient<ITimeBillingService, TimeBillingService>();

        return services;
    }
}
