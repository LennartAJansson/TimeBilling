namespace TimeBilling.Maui.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using GeneratedCode;

using TimeBilling.Contracts;
using TimeBilling.Maui.Models;

public class CustomerService : ICustomerService
{
  private readonly ITimeBillingApi api;
  private readonly IMapper mapper;

  public CustomerService(ITimeBillingApi api, IMapper mapper)
  {
    this.api = api;
    this.mapper = mapper;
  }

  public async Task<Customer> CreateCustomer(Customer customer)
  {
    CreateCustomerCommand request = mapper.Map<CreateCustomerCommand>(customer);
    CustomerResponse response = await api.CreateCustomer(request);
    return mapper.Map<Customer>(response);
  }

  public async Task<Customer> UpdateCustomer(Customer customer)
  {
    UpdateCustomerCommand request = mapper.Map<UpdateCustomerCommand>(customer);
    CustomerResponse response = await api.UpdateCustomer(request);
    return mapper.Map<Customer>(response);
  }

  public async Task<Customer> DeleteCustomer(Customer customer)
  {
    CustomerResponse response = await api.DeleteCustomer(customer.CustomerId);
    return mapper.Map<Customer>(response);
  }

  public async Task<Customer> GetCustomer(int customerId)
  {
    CustomerResponse response = await api.GetCustomer(customerId);
    return mapper.Map<Customer>(response);
  }

  public async Task<IEnumerable<Customer>> GetCustomers()
  {
    ICollection<CustomerResponse> customerResponse = await api.GetCustomers();
    IEnumerable<Customer> result = customerResponse.Select(p => mapper.Map<Customer>(p));
    return result;
  }
}
