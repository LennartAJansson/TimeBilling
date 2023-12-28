namespace TimeBilling.Api.Domain.Mapping;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using TimeBilling.Common.Contracts;
using TimeBilling.Model;

public sealed class CustomerRequestProfiles : Profile
{
  public CustomerRequestProfiles()
  {
    //TODO Update this to not use the model classes
    _ = CreateMap<Customer, CustomerResponse>()
        .ForCtorParam("CustomerId", options => options.MapFrom(c => c.Id))
        .ForCtorParam("Name", options => options.MapFrom(c => c.Name))
        .ForCtorParam("Workloads", opt => opt.MapFrom(src => src.Workloads.Select(w =>
          WorkloadResponse.Create(w.Id, w.Begin, w.End,
            PersonResponse.Create(w.Person!.Id, w.Person.Name!, Enumerable.Empty<WorkloadResponse>()),
            null))));

    _ = CreateMap<IEnumerable<Workload>, CustomerResponse>();

    _ = CreateMap<CreateCustomerRequest, Customer>();

    _ = CreateMap<UpdateCustomerRequest, Customer>()
        .ForMember("Id", options => options.MapFrom("CustomerId"));
  }
}
