namespace TimeBilling.Api.Domain.Abstract.Services;

using TimeBilling.Model;

public interface ITimeBillingQueryService
{
  Task<IEnumerable<Person>> ReadPeople();
  Task<Person?> ReadPerson(Guid personId);

  Task<IEnumerable<Customer>> ReadCustomers();
  Task<Customer?> ReadCustomer(Guid customerId);

  Task<IEnumerable<Workload>> ReadWorkloads();
  Task<Workload?> ReadWorkload(Guid workloadId);
  Task<IEnumerable<Workload>> ReadWorkloadsByPerson(Guid personId);
  Task<IEnumerable<Workload>> ReadWorkloadsByCustomer(Guid customerId);
}
