namespace TimeBilling.Maui.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using GeneratedCode;

using TimeBilling.Common.Contracts;
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

  public async Task<Workload> CreateWorkload(Workload workload)
  {
    CreateWorkloadRequest request = mapper.Map<CreateWorkloadRequest>(workload);
    WorkloadResponse response = await api.CreateWorkload(request);
    return mapper.Map<Workload>(response);
  }

  public async Task<Workload> UpdateWorkload(Workload workload)
  {
    UpdateWorkloadRequest request = mapper.Map<UpdateWorkloadRequest>(workload);
    WorkloadResponse response = await api.UpdateWorkload(request);
    return mapper.Map<Workload>(response);
  }

  public async Task<Workload> DeleteWorkload(Workload workload)
  {
    WorkloadResponse response = await api.DeleteWorkload(workload.WorkloadId);
    return mapper.Map<Workload>(response);
  }

  public async Task<Workload> GetWorkload(Guid workloadId)
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