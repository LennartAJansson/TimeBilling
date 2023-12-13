namespace TimeBilling.Domain.Mappings;

using AutoMapper;

using TimeBilling.Contracts;
using TimeBilling.Model;

public class PersonProfiles : Profile
{
  public PersonProfiles()
  {
    _ = CreateMap<Person, PersonResponse>()
        .ForCtorParam("PersonId", options => options.MapFrom("Id"))
        .ForCtorParam("Name", options => options.MapFrom("Name"));

    _ = CreateMap<CreatePersonCommand, Person>();

    _ = CreateMap<UpdatePersonCommand, Person>()
      .ForMember("Id", options => options.MapFrom("PersonId"));
  }
}
