namespace TimeBilling.Maui.Services;

using TimeBilling.Maui.Models;

public interface ICustomerService
{
  Task<Customer> CreateCustomer(Customer request);
  Task<Customer> UpdateCustomer(Customer request);
  Task<Customer> DeleteCustomer(Customer request);
  Task<Customer> GetCustomer(int id);
  Task<IEnumerable<Customer>> GetCustomers();
}