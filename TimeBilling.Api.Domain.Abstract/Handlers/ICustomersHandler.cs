namespace TimeBilling.Api.Domain.Abstract.Handlers;

using TimeBilling.Common.Contracts;

public interface ICustomersHandler
{
  Task<CommandResponse?> CreateCustomer(CreateCustomerRequest request);
  Task<CommandResponse?> UpdateCustomer(UpdateCustomerRequest request);
  Task<CommandResponse?> DeleteCustomer(DeleteCustomerRequest request);
  Task<IEnumerable<CustomerResponse>> GetCustomers(GetCustomersRequest request);
  Task<CustomerResponse?> GetCustomer(GetCustomerRequest request);
}
