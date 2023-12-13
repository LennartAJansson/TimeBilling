namespace TimeBilling.Domain.Mappings;

using AutoMapper;

using TimeBilling.Contracts;
using TimeBilling.Model;

public class PersonProfiles : Profile
{
  public PersonProfiles()
  {
    _ = CreateMap<Person, PersonResponse>()
        .ForCtorParam("PersonId", options => options.MapFrom(c => c.Id))
        .ForCtorParam("Name", options => options.MapFrom(c => c.Name))
        .ForCtorParam("Workloads", opt => opt.MapFrom(src => src.Workloads.Select(w =>
          WorkloadResponse.Create(w.Id, w.Begin, w.End,
            null,
            CustomerResponse.Create(w.Customer.Id, w.Customer.Name, Enumerable.Empty<WorkloadResponse>())))));

    _ = CreateMap<CreatePersonCommand, Person>();

    _ = CreateMap<UpdatePersonCommand, Person>()
      .ForMember("Id", options => options.MapFrom("PersonId"));
  }
}
