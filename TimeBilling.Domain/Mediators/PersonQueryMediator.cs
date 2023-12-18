namespace TimeBilling.Domain.Mediators;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using TimeBilling.Contracts;
using TimeBilling.Domain.Abstract.Services;
using TimeBilling.Model;

public class PersonQueryMediator :
    IRequestHandler<GetPeopleQuery, IEnumerable<PersonResponse>>,
    IRequestHandler<GetPersonQuery, PersonResponse>
{
  private readonly ILogger<PersonQueryMediator> logger;
  private readonly IMapper mapper;
  private readonly ITimeBillingQueryService service;

  public PersonQueryMediator(ILogger<PersonQueryMediator> logger, IMapper mapper, ITimeBillingQueryService service)
  {
    this.logger = logger;
    this.mapper = mapper;
    this.service = service;
  }

  public async Task<IEnumerable<PersonResponse>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
  {
    IEnumerable<Person> result = await service.ReadPeople();
    IEnumerable<PersonResponse> response = result.Select(c => mapper.Map<PersonResponse>(c));

    return response;
  }

  public async Task<PersonResponse> Handle(GetPersonQuery request, CancellationToken cancellationToken)
  {
    Person? result = await service.ReadPerson(request.PersonId);
    PersonResponse response = mapper.Map<PersonResponse>(result);

    return response;
  }
}
