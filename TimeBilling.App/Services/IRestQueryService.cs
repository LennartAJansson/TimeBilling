namespace TimeBilling.App.Services;

using TimeBilling.App.Models;

public interface IRestQueryService
{
    Task<CustomerModel> GetCustomer(int customerId);
    Task<ICollection<CustomerModel>> GetCustomers();

    Task<PersonModel> GetPerson(int personId);
    Task<ICollection<PersonModel>> GetPeople();

    Task<WorkloadModel> GetWorkload(int workloadId);
    Task<ICollection<WorkloadModel>> GetWorkloads();
    Task<ICollection<WorkloadModel>> GetWorkloadsByPerson(int personId);
    Task<ICollection<WorkloadModel>> GetWorkloadsByCustomer(int customerId);
}
