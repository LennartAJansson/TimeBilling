namespace TimeBilling.Common.Messaging.Services;

using System.Threading;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using NATS.Client.Core;
using NATS.Client.JetStream;
using NATS.Client.JetStream.Models;

using TimeBilling.Common.Messaging.Configuration;

//https://nats-io.github.io/nats.net.v2/documentation/intro.html?tabs=core-nats


//TODO Change this so it uses an ICommand:
public delegate void NatsCommandDelegate<T>(T data);// where T : string;

public class NatsListener : BackgroundService, IDisposable, ICommandListener
{
  public bool IsConnected { get; private set; }
  //TODO Change this so it uses an ICommand:
  public event NatsCommandDelegate<string>? CommandReceived;

  private readonly NatsConnection? connection;
  private readonly NatsJSContext? jetStream;
  private readonly NatsServiceConfig config;
  private INatsJSConsumer? consumer;
  private bool disposedValue;

  public NatsListener(NatsServiceConfig config)
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

  public override void Dispose()
  {
    Dispose(disposing: true);
    GC.SuppressFinalize(this);
    base.Dispose();
  }

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    if (jetStream is not null)
    {
      consumer = await jetStream.CreateOrUpdateConsumerAsync(config.Stream, new ConsumerConfig(config.Consumer));
      while (!stoppingToken.IsCancellationRequested)
      {
        await foreach (NatsJSMsg<string> jsMsg in consumer!.ConsumeAsync<string>(/*serializer: new CommandDeserializer(), */cancellationToken: stoppingToken))
        {
          await jsMsg.AckAsync();
          CommandReceived?.Invoke(jsMsg.Data);
        }
      }
    }
  }
}


