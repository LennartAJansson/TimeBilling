namespace TimeBilling.App.Services;

using TimeBilling.App.Models;

public interface IRestCommandService
{
    Task<CustomerModel> CreateCustomer(CustomerModel customer);
    Task<CustomerModel> UpdateCustomer(CustomerModel customer);
    Task<CustomerModel> DeleteCustomer(CustomerModel customer);

    Task<PersonModel> CreatePerson(PersonModel person);
    Task<PersonModel> UpdatePerson(PersonModel person);
    Task<PersonModel> DeletePerson(PersonModel person);

    Task<WorkloadModel> BeginWorkload(WorkloadModel customer);
    Task<WorkloadModel> EndWorkload(WorkloadModel customer);
    Task<WorkloadModel> DeleteWorkload(WorkloadModel customer);
}
