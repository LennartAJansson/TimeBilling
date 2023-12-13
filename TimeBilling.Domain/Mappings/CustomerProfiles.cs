namespace TimeBilling.Domain.Mappings;

using AutoMapper;

using TimeBilling.Contracts;
using TimeBilling.Model;

public class CustomerProfiles : Profile
{
  public CustomerProfiles()
  {
    _ = CreateMap<Customer, CustomerResponse>()
        .ForCtorParam("CustomerId", options => options.MapFrom(c => c.Id))
        .ForCtorParam("Name", options => options.MapFrom(c => c.Name))
        .ForCtorParam("Workloads", opt => opt.MapFrom(src => src.Workloads.Select(w =>
          WorkloadResponse.Create(w.Id, w.Begin, w.End,
            PersonResponse.Create(w.Person.Id, w.Person.Name, Enumerable.Empty<WorkloadResponse>()),
            null))));

    _ = CreateMap<IEnumerable<Workload>, CustomerResponse>();

    _ = CreateMap<CreateCustomerCommand, Customer>();

    _ = CreateMap<UpdateCustomerCommand, Customer>()
        .ForMember("Id", options => options.MapFrom("CustomerId"));
  }
}
