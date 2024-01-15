namespace TimeBilling.Api.Domain.Mediators;
using System.Threading.Tasks;

using MediatR;

using Microsoft.Extensions.Logging;

using TimeBilling.Common.Contracts;
using TimeBilling.Common.Messaging.Services;

public sealed class PersonApiCommandMediator(ILogger<PersonApiCommandMediator> logger, ICommandSender nats) :
    IRequestHandler<CreatePersonWithIdRequest, CommandResponse>,
    IRequestHandler<UpdatePersonRequest, CommandResponse>,
    IRequestHandler<DeletePersonRequest, CommandResponse>
{

  public async Task<CommandResponse> Handle(CreatePersonWithIdRequest request, CancellationToken cancellationToken)
  {
    CommandResponse response = await nats.SendAsync(request);
    //.CreatePerson(request);
    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }
    return response;
  }

  public async Task<CommandResponse> Handle(UpdatePersonRequest request, CancellationToken cancellationToken)
  {
    CommandResponse response = await nats.SendAsync(request);
    //.UpdatePerson(request);
    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }
    return response;
  }

  public async Task<CommandResponse> Handle(DeletePersonRequest request, CancellationToken cancellationToken)
  {
    CommandResponse response = await nats.SendAsync(request);
    //.DeletePerson(request);
    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }
    return response;
  }
}

