namespace TimeBilling.Maui.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using GeneratedCode;

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

  public Task<Customer> CreateCustomer(Customer request) => throw new NotImplementedException();
  public Task<Customer> UpdateCustomer(Customer request) => throw new NotImplementedException();
  public Task<Customer> DeleteCustomer(Customer request) => throw new NotImplementedException();
  public Task<Customer> GetCustomer(int id) => throw new NotImplementedException();
  public Task<IEnumerable<Customer>> GetCustomers() => throw new NotImplementedException();
}
