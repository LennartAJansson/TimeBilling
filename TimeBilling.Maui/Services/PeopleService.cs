namespace TimeBilling.Maui.Services;

using AutoMapper;

using GeneratedCode;

using TimeBilling.Common.Contracts;
using TimeBilling.Maui.Models;

public class PeopleService : IPeopleService
{
  private readonly ITimeBillingApi api;
  private readonly IMapper mapper;

  public PeopleService(ITimeBillingApi api, IMapper mapper)
  {
    this.api = api;
    this.mapper = mapper;
  }

  public async Task<Person> CreatePerson(Person person)
  {
    CreatePersonRequest request = mapper.Map<CreatePersonRequest>(person);
    PersonResponse response = await api.CreatePerson(request);
    return mapper.Map<Person>(response);
  }

  public async Task<Person> UpdatePerson(Person person)
  {
    UpdatePersonRequest request = mapper.Map<UpdatePersonRequest>(person);
    PersonResponse response = await api.UpdatePerson(request);
    return mapper.Map<Person>(response);
  }

  public async Task<Person> DeletePerson(Person person)
  {
    PersonResponse response = await api.DeletePerson(person.PersonId);
    return mapper.Map<Person>(response);
  }

  public async Task<Person> GetPerson(Guid personId)
  {
    PersonResponse response = await api.GetPerson(personId);
    return mapper.Map<Person>(response);
  }

  public async Task<IEnumerable<Person>> GetPeople()
  {
    ICollection<PersonResponse> peopleResponse = await api.GetPeople();
    IEnumerable<Person> result = peopleResponse.Select(p => mapper.Map<Person>(p));
    return result;
  }
}
