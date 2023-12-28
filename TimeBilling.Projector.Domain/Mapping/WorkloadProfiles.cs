namespace TimeBilling.Projector.Domain.Mapping;
using AutoMapper;

using TimeBilling.Common.Messaging.Contracts;
using TimeBilling.Model;

public sealed class WorkloadProfiles : Profile
{
  public WorkloadProfiles()
  {
    _ = CreateMap<CreateWorkloadCommand, Workload>()
        .ForMember("Id", options => options.MapFrom("WorkloadId"));

    _ = CreateMap<UpdateWorkloadCommand, Workload>()
        .ForMember("Id", options => options.MapFrom("WorkloadId"));
  }
}