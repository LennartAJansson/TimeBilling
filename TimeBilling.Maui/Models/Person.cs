namespace TimeBilling.Maui.Models;
public sealed class Person
{
  public Guid PersonId { get; set; }
  public required string Name { get; set; }
  public required ICollection<Workload> Workloads { get; set; }

  internal static Person? Clone(Person person) => new() { PersonId = person.PersonId, Name = person.Name, Workloads = person.Workloads };
}
