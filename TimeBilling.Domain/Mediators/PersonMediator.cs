namespace TimeBilling.Domain.Mediators;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using TimeBilling.Contracts;
using TimeBilling.Domain.Abstract;
using TimeBilling.Model;

public class PersonMediator :
    IRequestHandler<GetPeopleQuery, IEnumerable<PersonResponse>>,
    IRequestHandler<GetPersonQuery, PersonResponse>,
    IRequestHandler<CreatePersonCommand, PersonResponse>,
    IRequestHandler<UpdatePersonCommand, PersonResponse>,
    IRequestHandler<DeletePersonCommand, PersonResponse>
{
    private readonly ILogger<PersonMediator> logger;
    private readonly IMapper mapper;
    private readonly ITimeBillingService service;

    public PersonMediator(ILogger<PersonMediator> logger, IMapper mapper, ITimeBillingService service)
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
