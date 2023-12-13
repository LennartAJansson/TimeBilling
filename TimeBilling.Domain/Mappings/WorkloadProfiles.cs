namespace TimeBilling.Domain.Mappings;

using AutoMapper;

using TimeBilling.Contracts;
using TimeBilling.Model;

public class WorkloadProfiles : Profile
{
  public WorkloadProfiles()
  {
    _ = CreateMap<Workload, WorkloadResponse>()
        .ForCtorParam("WorkloadId", options => options.MapFrom("Id"))
        .ForCtorParam("Begin", options => options.MapFrom("Begin"))
        .ForCtorParam("End", options => options.MapFrom("End"))
        .ForCtorParam("Customer", options => options.MapFrom(w => CustomerResponse.Create(w.Customer.Id, w.Customer.Name, Enumerable.Empty<WorkloadResponse>())))
        .ForCtorParam("Person", options => options.MapFrom(w => PersonResponse.Create(w.Person.Id, w.Person.Name, Enumerable.Empty<WorkloadResponse>())));

    _ = CreateMap<CreateWorkloadCommand, Workload>()
        .ForMember("Begin", options => options.MapFrom("Begin"))
        .ForMember("CustomerId", options => options.MapFrom("CustomerId"))
        .ForMember("PersonId", options => options.MapFrom("PersonId"));

    _ = CreateMap<UpdateWorkloadCommand, Workload>()
        .ForMember("Id", options => options.MapFrom("WorkloadId"))
        .ForMember("End", options => options.MapFrom("End"));
  }
}
