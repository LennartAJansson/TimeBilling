namespace TimeBilling.Projector.Domain.Abstract.Services;

using TimeBilling.Model;

public interface IProjectorPersistanceService
{
  Task<Customer> CreateCustomer(Customer customer);
  Task<Customer?> UpdateCustomer(Customer customer);
  Task<Customer?> DeleteCustomer(Guid customerId);

  Task<Person> CreatePerson(Person person);
  Task<Person?> UpdatePerson(Person person);
  Task<Person?> DeletePerson(Guid personId);

  Task<Workload> CreateWorkload(Workload workload);
  Task<Workload?> UpdateWorkload(Guid workloadId, DateTimeOffset end);
  Task<Workload?> DeleteWorkload(Guid workloadId);
}