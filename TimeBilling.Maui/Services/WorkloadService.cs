namespace TimeBilling.Maui.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using GeneratedCode;

using TimeBilling.Contracts;
using TimeBilling.Maui.Models;

public class WorkloadService : IWorkloadService
{
  private readonly ITimeBillingApi api;
  private readonly IMapper mapper;

  public WorkloadService(ITimeBillingApi api, IMapper mapper)
  {
    this.api = api;
    this.mapper = mapper;
  }

  public async Task<Workload> BeginWorkload(Workload workload)
  {
    CreateWorkloadCommand request = mapper.Map<CreateWorkloadCommand>(workload);
    WorkloadResponse response = await api.BeginWorkload(request);
    return mapper.Map<Workload>(response);
  }

  public async Task<Workload> EndWorkload(Workload workload)
  {
    UpdateWorkloadCommand request = mapper.Map<UpdateWorkloadCommand>(workload);
    WorkloadResponse response = await api.EndWorkload(request);
    return mapper.Map<Workload>(response);
  }

  public async Task<Workload> DeleteWorkload(Workload workload)
  {
    WorkloadResponse response = await api.DeleteWorkload(workload.WorkloadId);
    return mapper.Map<Workload>(response);
  }

  public async Task<Workload> GetWorkload(int workloadId)
  {
    WorkloadResponse response = await api.GetWorkload(workloadId);
    return mapper.Map<Workload>(response);
  }

  public async Task<IEnumerable<Workload>> GetWorkloads()
  {
    ICollection<WorkloadResponse> workloadsResponse = await api.GetWorkloads();
    IEnumerable<Workload> result = workloadsResponse.Select(w => mapper.Map<Workload>(w));
    return result;
  }
}