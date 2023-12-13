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
        .ForCtorParam("CustomerId", options => options.MapFrom("CustomerId"))
        .ForCtorParam("PersonId", options => options.MapFrom("PersonId"));

    _ = CreateMap<BeginWorkloadCommand, Workload>()
        .ForCtorParam("Begin", options => options.MapFrom("Begin"))
        .ForCtorParam("CustomerId", options => options.MapFrom("CustomerId"))
        .ForCtorParam("PersonId", options => options.MapFrom("PersonId"));

    _ = CreateMap<EndWorkloadCommand, Workload>()
        .ForMember("Id", options => options.MapFrom("WorkloadId"))
        .ForCtorParam("End", options => options.MapFrom("End"));
  }
}
