namespace TimeBilling.Domain.Abstract.Services;

using TimeBilling.Model;

public interface ITimeBillingQueryService
{
  Task<IEnumerable<Person>> ReadPeople();
  Task<Person?> ReadPerson(int personId, bool relate = true);

  Task<IEnumerable<Customer>> ReadCustomers();
  Task<Customer?> ReadCustomer(int customerId, bool relate = true);

  Task<IEnumerable<Workload>> ReadWorkloads();
  Task<Workload?> ReadWorkload(int workloadId);
  Task<IEnumerable<Workload>> ReadWorkloadsByPerson(int personId);
  Task<IEnumerable<Workload>> ReadWorkloadsByCustomer(int customerId);
}
