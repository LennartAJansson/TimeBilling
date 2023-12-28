namespace TimeBilling.Api.Domain.Mapping;
using System.Linq;

using AutoMapper;

using TimeBilling.Common.Contracts;
using TimeBilling.Model;

public sealed class WorkloadRequestProfiles : Profile
{
  public WorkloadRequestProfiles()
  {
    //TODO Update this to not use the model classes
    _ = CreateMap<Workload, WorkloadResponse>()
        .ForCtorParam("WorkloadId", options => options.MapFrom("Id"))
        .ForCtorParam("Begin", options => options.MapFrom("Begin"))
        .ForCtorParam("End", options => options.MapFrom("End"))
        .ForCtorParam("Customer", options => options.MapFrom(w => CustomerResponse.Create(w.Customer!.Id, w.Customer.Name!, Enumerable.Empty<WorkloadResponse>())))
        .ForCtorParam("Person", options => options.MapFrom(w => PersonResponse.Create(w.Person!.Id, w.Person.Name!, Enumerable.Empty<WorkloadResponse>())));

    _ = CreateMap<CreateWorkloadRequest, Workload>()
        .ForMember("Begin", options => options.MapFrom("Begin"))
        .ForMember("CustomerId", options => options.MapFrom("CustomerId"))
        .ForMember("PersonId", options => options.MapFrom("PersonId"));

    _ = CreateMap<UpdateWorkloadRequest, Workload>()
        .ForMember("Id", options => options.MapFrom("WorkloadId"))
        .ForMember("End", options => options.MapFrom("End"));
  }
}