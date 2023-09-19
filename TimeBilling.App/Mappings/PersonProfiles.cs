namespace TimeBilling.App.Mappings;

using AutoMapper;

using TimeBilling.Contracts;
using TimeBilling.App.Models;

public class PersonProfiles : Profile
{
    public PersonProfiles()
    {
        CreateMap<PersonResponse, PersonModel>();
        //CreateMap<PersonModel, PersonResponse>()
        //    .ForCtorParam("PersonId", options => options.MapFrom("Id"));
        //CreateMap<CreatePersonCommand, PersonModel>();
        ////TODO! Fix all mappings! UpdatePersonCommand.PersonId maps to Person.Id
        //CreateMap<UpdatePersonCommand, PersonModel>();
    }
}
