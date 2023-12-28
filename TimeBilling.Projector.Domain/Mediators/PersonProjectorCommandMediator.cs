namespace TimeBilling.Projector.Domain.Mediators;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using TimeBilling.Common.Contracts;
using TimeBilling.Common.Messaging.Contracts;
using TimeBilling.Model;
using TimeBilling.Projector.Domain.Abstract.Services;

public sealed class PersonProjectorCommandMediator(ILogger<PersonProjectorCommandMediator> logger, IMapper mapper, IProjectorPersistanceService service) :
    IRequestHandler<CreatePersonCommand, CommandResponse>,
    IRequestHandler<UpdatePersonCommand, CommandResponse>,
    IRequestHandler<DeletePersonCommand, CommandResponse>
{
  private readonly ILogger<PersonProjectorCommandMediator> logger = logger;
  private readonly IMapper mapper = mapper;
  private readonly IProjectorPersistanceService service = service;

  public async Task<CommandResponse> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
  {
    Person person = mapper.Map<Person>(request);
    Person result = await service.CreatePerson(person);

    CommandResponse response = result is not null ?
      CommandResponse.Create(true, $"Person with id: {result.Id} created") :
      CommandResponse.Create(false, $"Person with id: {request.PersonId} NOT created");

    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }

    return response;
  }

  public async Task<CommandResponse> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
  {
    Person person = mapper.Map<Person>(request);
    Person? result = await service.UpdatePerson(person);

    CommandResponse response = result is not null ?
      CommandResponse.Create(true, $"Person with id: {result.Id} updated") :
      CommandResponse.Create(false, $"Person with id: {request.PersonId} NOT updated");

    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }

    return response;
  }

  public async Task<CommandResponse> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
  {
    Person? result = await service.DeletePerson(request.PersonId);

    CommandResponse response = result is not null ?
      CommandResponse.Create(true, $"Person with id: {result.Id} deleted") :
      CommandResponse.Create(false, $"Person with id: {request.PersonId} NOT deleted");

    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }

    return response;
  }
}

