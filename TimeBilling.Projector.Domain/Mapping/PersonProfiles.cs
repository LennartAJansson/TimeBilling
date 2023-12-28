namespace TimeBilling.Projector.Domain.Mapping;
using AutoMapper;

using TimeBilling.Common.Messaging.Contracts;
using TimeBilling.Model;

public sealed class PersonProfiles : Profile
{
  public PersonProfiles()
  {
    _ = CreateMap<CreatePersonCommand, Person>()
        .ForMember("Id", options => options.MapFrom("PersonId"));

    _ = CreateMap<UpdatePersonCommand, Person>()
        .ForMember("Id", options => options.MapFrom("PersonId"));
  }
}
