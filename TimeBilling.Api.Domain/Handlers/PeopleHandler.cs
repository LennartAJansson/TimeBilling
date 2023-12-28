namespace TimeBilling.Api.Domain.Handlers;

using MediatR;

using Microsoft.Extensions.Logging;

using TimeBilling.Api.Domain.Abstract.Handlers;
using TimeBilling.Common.Contracts;

public sealed class PeopleHandler(ILogger<PeopleHandler> logger, IMediator mediator) : IPeopleHandler
{
  private readonly ILogger<PeopleHandler> logger = logger;
  private readonly IMediator mediator = mediator;

  public async Task<CommandResponse?> CreatePerson(CreatePersonRequest request)
  {
    CommandResponse? response = await mediator.Send(CreatePersonWithIdRequest.Create(Guid.NewGuid(), request.Name));
    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }
    return response;
  }

  public async Task<CommandResponse?> UpdatePerson(UpdatePersonRequest request)
  {
    CommandResponse? response = await mediator.Send(request);
    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }
    return response;
  }

  public async Task<CommandResponse?> DeletePerson(DeletePersonRequest request)
  {
    CommandResponse? response = await mediator.Send(request);
    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }
    return response;
  }

  public async Task<PersonResponse?> GetPerson(GetPersonRequest request)
  {
    PersonResponse? response = await mediator.Send(request);
    return response;
  }

  public async Task<IEnumerable<PersonResponse>> GetPeople(GetPeopleRequest request)
  {
    IEnumerable<PersonResponse> response = await mediator.Send(request);
    return response;
  }
}
