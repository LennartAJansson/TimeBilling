namespace TimeBilling.Api.Domain.Mediators;
using System.Threading.Tasks;

using MediatR;

using Microsoft.Extensions.Logging;

using TimeBilling.Api.Domain.Abstract.Services;
using TimeBilling.Common.Contracts;

public sealed class PersonApiCommandMediator(ILogger<PersonApiCommandMediator> logger, IChannelService service) :
    IRequestHandler<CreatePersonWithIdRequest, CommandResponse>,
    IRequestHandler<UpdatePersonRequest, CommandResponse>,
    IRequestHandler<DeletePersonRequest, CommandResponse>
{
  private readonly ILogger<PersonApiCommandMediator> logger = logger;
  private readonly IChannelService service = service;

  public async Task<CommandResponse> Handle(CreatePersonWithIdRequest request, CancellationToken cancellationToken)
  {
    CommandResponse response = await service.CreatePerson(request);
    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }
    return response;
  }

  public async Task<CommandResponse> Handle(UpdatePersonRequest request, CancellationToken cancellationToken)
  {
    CommandResponse response = await service.UpdatePerson(request);
    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }
    return response;
  }

  public async Task<CommandResponse> Handle(DeletePersonRequest request, CancellationToken cancellationToken)
  {
    CommandResponse response = await service.DeletePerson(request);
    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }
    return response;
  }
}

