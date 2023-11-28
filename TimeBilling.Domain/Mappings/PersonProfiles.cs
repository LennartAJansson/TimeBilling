namespace TimeBilling.Domain.Mappings;

using AutoMapper;

using TimeBilling.Contracts;
using TimeBilling.Model;

public class PersonProfiles : Profile
{
  public PersonProfiles()
  {
    _ = CreateMap<Person, PersonResponse>()
        .ForCtorParam("PersonId", options => options.MapFrom("Id"));
    _ = CreateMap<CreatePersonCommand, Person>();
    //TODO! Fix all mappings! UpdatePersonCommand.PersonId maps to Person.Id
    _ = CreateMap<UpdatePersonCommand, Person>()
      .ForMember("Id", options => options.MapFrom("PersonId"));
  }
}
