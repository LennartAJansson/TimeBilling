namespace TimeBilling.Api.Domain.Mapping;
using System.Linq;

using AutoMapper;

using TimeBilling.Common.Contracts;
using TimeBilling.Model;

public sealed class PersonRequestProfiles : Profile
{
  public PersonRequestProfiles()
  {
    //TODO Update this to not use the model classes
    _ = CreateMap<Person, PersonResponse>()
        .ForCtorParam("PersonId", options => options.MapFrom(c => c.Id))
        .ForCtorParam("Name", options => options.MapFrom(c => c.Name))
        .ForCtorParam("Workloads", opt => opt.MapFrom(src => src.Workloads.Select(w =>
          WorkloadResponse.Create(w.Id, w.Begin, w.End,
            null,
            CustomerResponse.Create(w.Customer!.Id, w.Customer.Name!, Enumerable.Empty<WorkloadResponse>())))));

    _ = CreateMap<CreatePersonRequest, Person>();

    _ = CreateMap<UpdatePersonRequest, Person>()
      .ForMember("Id", options => options.MapFrom("PersonId"));
  }
}
