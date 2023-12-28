namespace TimeBilling.Common.Messaging.Extensions;

using System.Threading.Channels;

using Microsoft.Extensions.DependencyInjection;

using TimeBilling.Api.Domain.Abstract.Services;
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
}
