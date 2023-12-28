namespace TimeBilling.Maui.Services;

using TimeBilling.Maui.Models;

public interface IWorkloadService
{
  Task<Workload> CreateWorkload(Workload workload);
  Task<Workload> UpdateWorkload(Workload workload);
  Task<Workload> DeleteWorkload(Workload workload);
  Task<Workload> GetWorkload(Guid id);
  Task<IEnumerable<Workload>> GetWorkloads();
}