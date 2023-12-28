namespace TimeBilling.Maui.Services;

using TimeBilling.Maui.Models;

public interface ICustomerService
{
  Task<Customer> CreateCustomer(Customer customer);
  Task<Customer> UpdateCustomer(Customer customer);
  Task<Customer> DeleteCustomer(Customer customer);
  Task<Customer> GetCustomer(Guid id);
  Task<IEnumerable<Customer>> GetCustomers();
}