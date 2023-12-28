namespace TimeBilling.Projector.Domain.Services;

using System.Threading.Channels;

using MediatR;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using TimeBilling.Common.Messaging.Contracts;

public sealed class ChannelListener(ILogger<ChannelListener> logger, IMediator mediator, Channel<ICommand> channel) : BackgroundService
{
  private readonly ILogger<ChannelListener> logger = logger;
  private readonly IMediator mediator = mediator;
  private readonly Channel<ICommand> channel = channel;

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    while (!stoppingToken.IsCancellationRequested)
    {
      _ = await channel.Reader.WaitToReadAsync(stoppingToken);
      if (channel.Reader.TryRead(out ICommand? command))
      {
        object? response = await mediator.Send(command, stoppingToken);
        if (logger.IsEnabled(LogLevel.Information))
        {
          logger.LogInformation("Command {command} executed with response {response}", command, response);
        }
      }
    }
  }
}
