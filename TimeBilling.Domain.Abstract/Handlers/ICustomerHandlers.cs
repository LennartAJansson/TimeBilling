namespace TimeBilling.Domain.Abstract.Handlers;

using TimeBilling.Contracts;

public interface ICustomerHandlers
{
    Task<IEnumerable<CustomerResponse>> GetCustomers(GetCustomersQuery request);
    Task<CustomerResponse?> GetCustomer(GetCustomerQuery request);
    Task<CustomerResponse?> CreateCustomer(CreateCustomerCommand request);
    Task<CustomerResponse?> UpdateCustomer(UpdateCustomerCommand request);
    Task<CustomerResponse?> DeleteCustomer(DeleteCustomerCommand request);
}
