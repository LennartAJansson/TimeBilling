namespace TimeBilling.Common.Messaging.Services;

using System.Text.Json;

using CloudNative.CloudEvents;

using Microsoft.Extensions.Logging;

using NATS.Client.Core;
using NATS.Client.JetStream;
using NATS.Client.JetStream.Models;

using Newtonsoft.Json;

using TimeBilling.Common.Contracts;
using TimeBilling.Common.Messaging.Configuration;

public class NatsSender : IDisposable, ICommandSender
{
  public bool IsConnected { get; private set; }

  private readonly NatsConnection? connection;
  private readonly NatsJSContext? jetStream;
  private readonly NatsServiceConfig config;
  private bool disposedValue;

  public NatsSender(NatsServiceConfig config)
  {
    NatsOpts opts = NatsOpts.Default with
    {
      Url = $"nats://{config.Host}:{config.Port}",
      LoggerFactory = LoggerFactory.Create(builder => builder.AddConsole())
    };
    connection = new NatsConnection(opts);
    jetStream = new NatsJSContext(connection);
    connection.ConnectionOpened += Connection_ConnectionOpened;
    connection.ConnectionDisconnected += Connection_ConnectionDisconnected;
    this.config = config;
  }

  private void Connection_ConnectionOpened(object? sender, string e) => IsConnected = true;
  private void Connection_ConnectionDisconnected(object? sender, string e) => IsConnected = false;

  public async Task<CommandResponse> SendAsync(object command)
  {
    _ = await jetStream.CreateStreamAsync(new StreamConfig(name: config.Stream, subjects: config.Subjects));

    CloudEvent evt = new()
    {
      Id = Guid.NewGuid().ToString(),
      Subject = config.Subject,
      Data = JsonConvert.SerializeObject(command),
      Type = command.GetType().FullName,
      Time = DateTimeOffset.UtcNow
    };

    string json = JsonConvert.SerializeObject(evt);

    PubAckResponse ack = await jetStream.PublishAsync(subject: config.Subject, data: json);
    ack.EnsureSuccess();
    return new CommandResponse(true, $"Sequence: {ack.Seq}, Subject: {evt.Subject} Id: {evt.Id}, Type: {evt.Type}, Time: {evt.Time}");
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!disposedValue)
    {
      if (disposing)
      {
        if (connection is not null)
        {
          connection.ConnectionOpened -= Connection_ConnectionOpened;
          connection.ConnectionDisconnected -= Connection_ConnectionDisconnected;
          _ = connection.DisposeAsync().AsTask().Wait(connection.Opts.CommandTimeout);
        }

      }
      disposedValue = true;
    }
  }

  public void Dispose()
  {
    Dispose(disposing: true);
    GC.SuppressFinalize(this);
  }
}


