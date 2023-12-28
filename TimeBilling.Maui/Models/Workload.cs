namespace TimeBilling.Maui.Models;

public sealed class Workload
{
  public Guid WorkloadId { get; set; }
  //public int CustomerId { get; set; }
  //public int PersonId { get; set; }
  public DateTimeOffset Begin { get; set; }
  public DateTimeOffset End { get; set; }
  public TimeSpan Total => End - Begin;

  public Customer? Customer { get; set; }
  public Person? Person { get; set; }

  internal static Workload? Clone(Workload workload) => new()
  {
    WorkloadId = workload.WorkloadId,
    //PersonId = workload.PersonId,
    //CustomerId = workload.CustomerId,
    Begin = workload.Begin,
    End = workload.End,
    Customer = workload.Customer,
    Person = workload.Person
  };

}
