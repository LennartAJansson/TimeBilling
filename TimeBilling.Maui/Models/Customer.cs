namespace TimeBilling.Maui.Models;

public sealed class Customer
{
  public int CustomerId { get; set; }
  public required string Name { get; set; }

  internal static Customer? Create(Customer customer) => new() { CustomerId = customer.CustomerId, Name = customer.Name };
}
