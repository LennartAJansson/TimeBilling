namespace TimeBilling.Model;

public sealed class Workload : Entity
{
  public Guid CustomerId { get; set; }
  public Guid PersonId { get; set; }
  public DateTimeOffset Begin { get; set; }
  public DateTimeOffset? End { get; set; }
  public TimeSpan Total => End.HasValue ? End.Value - Begin : DateTimeOffset.Now - Begin;

  public Customer? Customer { get; set; }
  public Person? Person { get; set; }
}
