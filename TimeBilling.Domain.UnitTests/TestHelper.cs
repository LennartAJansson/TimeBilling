using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using TimeBilling.Domain.Abstract.Services;
using TimeBilling.Domain.Mediators;
using TimeBilling.Persistance.Context;

using TimeBilling.Persistance.Services;

public static class TestHelper
{
    public static IServiceProvider GetServiceProvider() => new ServiceCollection()
        .AddLogging(builder => builder.SetMinimumLevel(LogLevel.Trace))

        //.AddDomainRegistrations()
        .AddAutoMapper(typeof(DomainExtensions).Assembly)
        .AddMediatR(configuration =>
        {
            _ = configuration.RegisterServicesFromAssemblyContaining(typeof(CustomerMediator));
        })


        //.AddPersistanceRegistrations()
        .AddDbContext<ITimeBillingDbContext, TimeBillingDbContext>(builder =>
        {
            string connectionString = "Server=(localdb)\\MsSqlLocalDb;Database=TestTimeBillingDb;Trusted_Connection=True;MultipleActiveResultSets=true";
            _ = builder.UseSqlServer(connectionString);

            DbContextOptions<TimeBillingDbContext>? options = builder.Options as DbContextOptions<TimeBillingDbContext>;
            using TimeBillingDbContext ctx = new(options!);
            ctx.Database.Migrate();
        })
        .AddTransient<ITimeBillingService, TimeBillingService>()

        .BuildServiceProvider();
}