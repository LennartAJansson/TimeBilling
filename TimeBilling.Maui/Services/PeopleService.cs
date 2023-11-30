namespace TimeBilling.Maui.Services;

using AutoMapper;

using GeneratedCode;

using TimeBilling.Contracts;
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

  public Task<Person> CreatePerson(Person person) => throw new NotImplementedException();

  public async Task<Person> UpdatePerson(Person person)
  {
    UpdatePersonCommand request = mapper.Map<UpdatePersonCommand>(person);
    PersonResponse response = await api.UpdatePerson(request);
    return mapper.Map<Person>(response);
  }

  public Task<Person> DeletePerson(Person person) => throw new NotImplementedException();

  public Task<Person> GetPerson(int id) => throw new NotImplementedException();

  public async Task<IEnumerable<Person>> GetPeople()
  {
    ICollection<PersonResponse> peopleResponse = await api.GetPeople();
    IEnumerable<Person> result = peopleResponse.Select(p => mapper.Map<Person>(p));
    return result;
  }
}
