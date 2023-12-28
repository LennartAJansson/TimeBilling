namespace TimeBilling.Api.Domain.Mediators;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using TimeBilling.Api.Domain.Abstract.Services;
using TimeBilling.Common.Contracts;
using TimeBilling.Model;

public sealed class PersonApiQueryMediator(ILogger<PersonApiQueryMediator> logger, IMapper mapper, ITimeBillingQueryService service) :
    IRequestHandler<GetPeopleRequest, IEnumerable<PersonResponse>>,
    IRequestHandler<GetPersonRequest, PersonResponse>
{
  private readonly ILogger<PersonApiQueryMediator> logger = logger;
  private readonly IMapper mapper = mapper;
  private readonly ITimeBillingQueryService service = service;

  public async Task<IEnumerable<PersonResponse>> Handle(GetPeopleRequest request, CancellationToken cancellationToken)
  {
    IEnumerable<Person> result = await service.ReadPeople();
    IEnumerable<PersonResponse> response = result.Select(mapper.Map<PersonResponse>);

    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response:\n{response}", string.Join('\n', response));
    }

    return response;
  }

  public async Task<PersonResponse> Handle(GetPersonRequest request, CancellationToken cancellationToken)
  {
    Person? result = await service.ReadPerson(request.PersonId);
    PersonResponse response = mapper.Map<PersonResponse>(result);

    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }

    return response;
  }
}

