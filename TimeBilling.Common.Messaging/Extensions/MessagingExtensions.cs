namespace TimeBilling.Common.Messaging.Extensions;

using System.Threading.Channels;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TimeBilling.Api.Domain.Abstract.Services;
using TimeBilling.Common.Messaging.Configuration;
using TimeBilling.Common.Messaging.Contracts;
using TimeBilling.Common.Messaging.Services;

public static class MessagingExtensions
{
  public static IServiceCollection AddMessagingRegistrations(this IServiceCollection services)
  {
    //TODO Make it possible to switch between implementations of Channel's Reader and Writer
    //TODO Move this ChannelService away from Common since it's for Api only
    _ = services.AddTransient<IChannelService, ChannelService>();
    _ = services.AddSingleton<Channel<ICommand>>(Channel.CreateUnbounded<ICommand>());

    return services;
  }

  public static IServiceCollection AddNatsSender(this IServiceCollection services, IConfiguration configuration)
  {

    NatsServiceConfig? config = configuration.GetSection("Nats").Get<NatsServiceConfig>()
      ?? throw new ArgumentException("NATS config not found");
    _ = services.AddSingleton(config);
    _ = services.AddSingleton<ICommandSender>(serviceProvider => new NatsSender(config));

    return services;
  }

  public static IServiceCollection AddNatsListener(this IServiceCollection services, IConfiguration configuration)
  {

    NatsServiceConfig? config = configuration.GetSection("Nats").Get<NatsServiceConfig>()
      ?? throw new ArgumentException("NATS config not found");
    _ = services.AddSingleton(config);
    //NatsListener is a HostedService but used injected and started as a singleton into a Worker:
    _ = services.AddSingleton<ICommandListener>(serviceProvider => new NatsListener(config));

    return services;
  }
}
