namespace TimeBilling.Maui.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using GeneratedCode;

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

  public Task<Workload> BeginWorkload(Workload workload) => throw new NotImplementedException();
  public Task<Workload> EndWorkload(Workload workload) => throw new NotImplementedException();
  public Task<Workload> DeleteWorkload(Workload workload) => throw new NotImplementedException();
  public Task<Workload> GetWorkload(int id) => throw new NotImplementedException();
  public Task<IEnumerable<Workload>> GetWorkloads() => throw new NotImplementedException();
}