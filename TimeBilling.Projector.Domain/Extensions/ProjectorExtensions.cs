namespace TimeBilling.Projector.Domain.Extensions;

using Microsoft.Extensions.DependencyInjection;

using TimeBilling.Projector.Domain.Mediators;
using TimeBilling.Projector.Domain.Services;

public static class ProjectorExtensions
{
  public static IServiceCollection AddProjectorDomainRegistrations(this IServiceCollection services)
  {
    _ = services.AddAutoMapper(typeof(ProjectorExtensions).Assembly);

    _ = services.AddMediatR(configuration =>
    {
      _ = configuration.RegisterServicesFromAssemblyContaining(typeof(CustomerProjectorCommandMediator));
    });

    _ = services.AddHostedService<ChannelListener>();

    return services;
  }
}