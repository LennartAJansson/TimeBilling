namespace TimeBilling.Model;

public class Person : Entity
{
    public string? Name { get; set; }

    public ICollection<Workload> Workloads { get; set; } = new HashSet<Workload>();

}
