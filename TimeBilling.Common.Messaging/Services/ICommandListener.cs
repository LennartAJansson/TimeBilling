namespace TimeBilling.Common.Messaging.Services;

using CloudNative.CloudEvents;

using Microsoft.Extensions.Hosting;

public interface ICommandListener : IHostedService
{
    bool IsConnected { get; }
    event NatsCommandDelegate<string>? CommandReceived;
}


