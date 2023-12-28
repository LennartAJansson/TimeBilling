namespace TimeBilling.Api.Domain.Abstract.Handlers;

using TimeBilling.Common.Contracts;

public interface IWorkloadsHandler
{
  Task<CommandResponse?> CreateWorkload(CreateWorkloadRequest request);
  Task<CommandResponse?> UpdateWorkload(UpdateWorkloadRequest request);
  Task<CommandResponse?> DeleteWorkload(DeleteWorkloadRequest request);
  Task<IEnumerable<WorkloadResponse>> GetWorkloads(GetWorkloadsRequest request);
  Task<WorkloadResponse?> GetWorkload(GetWorkloadRequest request);
  Task<IEnumerable<WorkloadResponse>> GetWorkloadsByCustomer(GetWorkloadsByCustomerRequest getWorkloadsByCustomerQuery);
  Task<IEnumerable<WorkloadResponse>> GetWorkloadsByPerson(GetWorkloadsByPersonRequest getWorkloadsByPersonQuery);
}
