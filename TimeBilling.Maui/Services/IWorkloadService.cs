namespace TimeBilling.Maui.Services;

using TimeBilling.Maui.Models;

public interface IWorkloadService
{
  Task<Workload> BeginWorkload(Workload workload);
  Task<Workload> EndWorkload(Workload workload);
  Task<Workload> DeleteWorkload(Workload workload);
  Task<Workload> GetWorkload(int id);
  Task<IEnumerable<Workload>> GetWorkloads();
}