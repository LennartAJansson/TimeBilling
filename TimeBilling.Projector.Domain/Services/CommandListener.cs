namespace TimeBilling.Projector.Domain.Services;

using CloudNative.CloudEvents;

using MediatR;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using TimeBilling.Common.Messaging.Contracts;
using TimeBilling.Common.Messaging.Services;

public sealed class CommandListener : BackgroundService
{
  private readonly ILogger<CommandListener> logger;
  private readonly IMediator mediator;
  private readonly ICommandListener service;

  public CommandListener(ILogger<CommandListener> logger, IMediator mediator, ICommandListener service)
  {
    this.logger = logger;
    this.mediator = mediator;
    this.service = service;
    this.service.CommandReceived += Service_CommandReceived;
  }

  //TODO Implement receiver
  private void Service_CommandReceived(string data)
  {
    CloudEvent? evt = JsonConvert.DeserializeObject<CloudEvent>(data);
    if(evt is null || evt.Data is null || evt.Type is null) 
    {
      logger.LogError("Invalid command received: {data}", data);
      return;
    }

    string text = $"Subject: {evt.Subject} Id: {evt.Id}, Type: {evt.Type}, Time: {evt.Time}, Name: {evt.Data}";
    logger.LogInformation("Processed: {text}", text);

    if (evt.Type.Contains("CreateCustomerWithIdRequest"))
    {
      CreateCustomerCommand? source = JsonConvert.DeserializeObject<CreateCustomerCommand>((string)evt.Data);
      _ = mediator.Send(source);
    }
    else if (evt.Type.Contains("UpdateCustomerRequest"))
    {
      UpdateCustomerCommand? source = JsonConvert.DeserializeObject<UpdateCustomerCommand>((string)evt.Data);
      _ = mediator.Send(source);
    }
    else if (evt.Type.Contains("DeleteCustomerRequest"))
    {
      DeleteCustomerCommand? source = JsonConvert.DeserializeObject<DeleteCustomerCommand>((string)evt.Data);
      _ = mediator.Send(source);
    }
    else if (evt.Type.Contains("CreatePersonWithIdRequest"))
    {
      CreatePersonCommand? source = JsonConvert.DeserializeObject<CreatePersonCommand>((string)evt.Data);
      _ = mediator.Send(source);
    }
    else if (evt.Type.Contains("UpdatePersonRequest"))
    {
      UpdatePersonCommand? source = JsonConvert.DeserializeObject<UpdatePersonCommand>((string)evt.Data);
      _ = mediator.Send(source);
    }
    else if (evt.Type.Contains("DeletePersonRequest"))
    {
      DeletePersonCommand? source = JsonConvert.DeserializeObject<DeletePersonCommand>((string)evt.Data);
      _ = mediator.Send(source);
    }
    else if (evt.Type.Contains("CreateWorkloadWithIdRequest"))
    {
      CreateWorkloadCommand? source = JsonConvert.DeserializeObject<CreateWorkloadCommand>((string)evt.Data);
      _ = mediator.Send(source);
    }
    else if (evt.Type.Contains("UpdateWorkloadRequest"))
    {
      UpdateWorkloadCommand? source = JsonConvert.DeserializeObject<UpdateWorkloadCommand>((string)evt.Data);
      _ = mediator.Send(source);
    }
    else if (evt.Type.Contains("DeleteWorkloadRequest"))
    {
      DeleteWorkloadCommand? source = JsonConvert.DeserializeObject<DeleteWorkloadCommand>((string)evt.Data);
      _ = mediator.Send(source);
    }
  }

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    await service.StartAsync(stoppingToken);
    while (!stoppingToken.IsCancellationRequested)
    {
      logger.LogInformation("Waiting for messages...");
      await Task.Delay(30000, stoppingToken);
    }
    await service.StopAsync(stoppingToken);
  }
}
