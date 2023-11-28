namespace TimeBilling.Maui.Services;

using AutoMapper;

using GeneratedCode;

using TimeBilling.Maui.Models;

public class TimeBillingService : ITimeBillingService
{
  private readonly ITimeBillingApi api;
  private readonly IMapper mapper;

  public TimeBillingService(ITimeBillingApi api, IMapper mapper)
  {
    this.api = api;
    this.mapper = mapper;
  }

  public async Task<ICollection<Person>> GetPeople()
  {
    ICollection<PersonResponse> peopleResponse = await api.GetPeople();

    List<Person> result = peopleResponse.Select(p => mapper.Map<Person>(p)).ToList();

    return result;
  }

  public async Task UpdatePerson(Person? person)
  {
    UpdatePersonCommand request = mapper.Map<UpdatePersonCommand>(person);
    _ = await api.UpdatePerson(request);
  }
}
