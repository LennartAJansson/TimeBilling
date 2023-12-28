namespace TimeBilling.Maui.Models;

public sealed class Customer
{
  public Guid CustomerId { get; set; }
  public required string Name { get; set; }
  public required ICollection<Workload> Workloads { get; set; }
  internal static Customer? Clone(Customer customer) => new() { CustomerId = customer.CustomerId, Name = customer.Name, Workloads = customer.Workloads };
}
