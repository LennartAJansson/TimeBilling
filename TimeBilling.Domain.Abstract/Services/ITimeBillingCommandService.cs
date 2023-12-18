namespace TimeBilling.Domain.Abstract.Services;

using TimeBilling.Model;

public interface ITimeBillingCommandService
{
  Task<Customer> CreateCustomer(Customer customer);
  Task<Customer?> UpdateCustomer(Customer customer);
  Task<Customer?> DeleteCustomer(int customerId);
  //Task<Customer?> ReadCustomer(int customerId);
  //Task<IEnumerable<Customer>> ReadCustomers();

  Task<Person> CreatePerson(Person person);
  Task<Person?> UpdatePerson(Person person);
  Task<Person?> DeletePerson(int personId);
  //Task<Person?> ReadPerson(int personId);
  //Task<IEnumerable<Person>> ReadPeople();

  Task<Workload> CreateWorkload(Workload workload);
  Task<Workload?> UpdateWorkload(int workloadId, DateTimeOffset end);
  Task<Workload?> DeleteWorkload(int workloadId);
  //Task<Workload?> ReadWorkload(int workloadId);
  //Task<IEnumerable<Workload>> ReadWorkloads();
  //Task<IEnumerable<Workload>> ReadWorkloadsByPerson(int personId);
  //Task<IEnumerable<Workload>> ReadWorkloadsByCustomer(int customerId);
}