namespace TimeBilling.Domain.Mediators;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using TimeBilling.Contracts;
using TimeBilling.Domain.Abstract.Services;
using TimeBilling.Model;

public class PersonCommandMediator :
    IRequestHandler<CreatePersonCommand, PersonResponse>,
    IRequestHandler<UpdatePersonCommand, PersonResponse>,
    IRequestHandler<DeletePersonCommand, PersonResponse>
{
  private readonly ILogger<PersonCommandMediator> logger;
  private readonly IMapper mapper;
  private readonly ITimeBillingCommandService service;

  public PersonCommandMediator(ILogger<PersonCommandMediator> logger, IMapper mapper, ITimeBillingCommandService service)
  {
    this.logger = logger;
    this.mapper = mapper;
    this.service = service;
  }

  public async Task<PersonResponse> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
  {
    Person person = mapper.Map<Person>(request);
    Person result = await service.CreatePerson(person);
    PersonResponse response = mapper.Map<PersonResponse>(result);

    return response;
  }

  public async Task<PersonResponse> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
  {
    Person person = mapper.Map<Person>(request);
    Person result = await service.UpdatePerson(person);
    PersonResponse response = mapper.Map<PersonResponse>(result);

    return response;
  }

  public async Task<PersonResponse> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
  {
    Person result = await service.DeletePerson(request.PersonId);
    PersonResponse response = mapper.Map<PersonResponse>(result);

    return response;
  }
}
