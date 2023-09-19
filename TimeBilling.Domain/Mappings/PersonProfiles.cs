namespace TimeBilling.Domain.Mappings;

using AutoMapper;

using TimeBilling.Contracts;
using TimeBilling.Model;

public class PersonProfiles : Profile
{
    public PersonProfiles()
    {
        CreateMap<Person, PersonResponse>()
            .ForCtorParam("PersonId", options => options.MapFrom("Id"));
        CreateMap<CreatePersonCommand, Person>();
        //TODO! Fix all mappings! UpdatePersonCommand.PersonId maps to Person.Id
        CreateMap<UpdatePersonCommand, Person>();
    }
}
