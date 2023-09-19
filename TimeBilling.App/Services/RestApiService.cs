namespace TimeBilling.App.Services;

using AutoMapper;

using GeneratedCode;

using TimeBilling.App.Models;
using TimeBilling.Contracts;

public sealed class RestApiService : IRestApiService
{
    private readonly ITimeBillingApi api;
    private readonly IMapper mapper;

    public RestApiService(ITimeBillingApi api, IMapper mapper)
    {
        this.api = api;
        this.mapper = mapper;
    }
    public async Task<CustomerModel> CreateCustomer(CustomerModel customer)
    {
        var command = mapper.Map<CreateCustomerCommand>(customer);

        var response = await api.CreateCustomer(command);

        var result = mapper.Map<CustomerModel>(response);

        return result;
    }

    public async Task<PersonModel> CreatePerson(PersonModel person)
    {
        var command = mapper.Map<CreatePersonCommand>(person);

        var response = await api.CreatePerson(command);

        var result = mapper.Map<PersonModel>(response);

        return result;
    }

    public async Task<WorkloadModel> BeginWorkload(WorkloadModel workload)
    {
        var command = mapper.Map<BeginWorkloadCommand>(workload);

        var response = await api.BeginWorkload(command);

        var result = mapper.Map<WorkloadModel>(response);

        return result;
    }

    public async Task<CustomerModel> UpdateCustomer(CustomerModel customer)
    {
        var command = mapper.Map<UpdateCustomerCommand>(customer);

        var response = await api.UpdateCustomer(command);

        var result = mapper.Map<CustomerModel>(response);

        return result;
    }

    public async Task<PersonModel> UpdatePerson(PersonModel person)
    {
        var command = mapper.Map<UpdatePersonCommand>(person);

        var response = await api.UpdatePerson(command);

        var result = mapper.Map<PersonModel>(response);

        return result;
    }

    public async Task<WorkloadModel> EndWorkload(WorkloadModel workload)
    {
        var command = mapper.Map<EndWorkloadCommand>(workload);

        var response = await api.EndWorkload(command);

        var result = mapper.Map<WorkloadModel>(response);

        return result;
    }

    public async Task<CustomerModel> DeleteCustomer(CustomerModel customer)
    {
        var response = await api.DeleteCustomer(customer.CustomerId);

        var result = mapper.Map<CustomerModel>(response);

        return result;
    }

    public async Task<PersonModel> DeletePerson(PersonModel person)
    {
        var response = await api.DeleteCustomer(person.PersonId);

        var result = mapper.Map<PersonModel>(response);

        return result;
    }

    public async Task<WorkloadModel> DeleteWorkload(WorkloadModel workload)
    {
        var response = await api.DeleteWorkload(workload.WorkloadId);

        var result = mapper.Map<WorkloadModel>(response);

        return result;
    }

    public async Task<CustomerModel> GetCustomer(int customerId)
    {
        var response = await api.GetCustomer(customerId);
        
        var result = mapper.Map<CustomerModel>(response);
        
        return result;
    }

    public async Task<ICollection<CustomerModel>> GetCustomers()
    {
        var response = await api.GetCustomers();

        var result = response.Select(customerResponse=>mapper.Map<CustomerModel>(customerResponse)).ToList();
        
        return result;
    }

    public async Task<PersonModel> GetPerson(int personId)
    {
        var response = await api.GetPerson(personId);

        var result = mapper.Map<PersonModel>(response);

        return result;
    }

    public async Task<ICollection<PersonModel>> GetPeople()
    {
        var response = await api.GetPeople();

        var result = response.Select(personResponse => mapper.Map<PersonModel>(personResponse)).ToList();

        return result;
    }

    public async Task<WorkloadModel> GetWorkload(int workloadId)
    {
        var response = await api.GetWorkload(workloadId);

        var result = mapper.Map<WorkloadModel>(response);

        return result;
    }

    public async Task<ICollection<WorkloadModel>> GetWorkloads()
    {
        var response = await api.GetWorkloads();

        var result = response.Select(workloadResponse => mapper.Map<WorkloadModel>(workloadResponse)).ToList();

        return result;
    }

    public async Task<ICollection<WorkloadModel>> GetWorkloadsByCustomer(int customerId)
    {
        var response = await api.GetWorkloadsByCustomer(customerId);

        var result = response.Select(workloadResponse => mapper.Map<WorkloadModel>(workloadResponse)).ToList();

        return result;
    }

    public async Task<ICollection<WorkloadModel>> GetWorkloadsByPerson(int personId)
    {
        var response = await api.GetWorkloadsByPerson(personId);

        var result = response.Select(workloadResponse => mapper.Map<WorkloadModel>(workloadResponse)).ToList();

        return result;
    }
}