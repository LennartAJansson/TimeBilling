namespace TimeBilling.Projector.Persistance.Extensions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using TimeBilling.Projector.Domain.Abstract.Services;
using TimeBilling.Projector.Persistance.Context;
using TimeBilling.Projector.Persistance.Services;

public static class PersistanceExtensions
{
  public static IServiceCollection AddProjectorPersistanceRegistrations(this IServiceCollection services, string connectionString)
  {
    _ = services.AddDbContext<ITimeBillingDbContext, TimeBillingDbContext>(builder =>
    {
      ServerVersion serverVersion = ServerVersion.AutoDetect(connectionString);
      _ = builder.UseMySql(connectionString, serverVersion)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors();
    }, ServiceLifetime.Transient, ServiceLifetime.Transient);
    _ = services.AddTransient<IProjectorPersistanceService, ProjectorPersistanceService>();

    return services;
  }

  public static IHost ConfigurePersistance(this IHost app)
  {
    using IServiceScope scope = app.Services.CreateScope();
    _ = scope.ServiceProvider.GetRequiredService<TimeBillingDbContext>().EnsureDbExists();

    return app;
  }
}
