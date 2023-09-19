namespace TimeBilling.App.Models;

public class WorkloadModel
{
    public int WorkloadId { get; set; }
    public DateTimeOffset Begin { get; set; }
    public DateTimeOffset End { get; set; }
    public TimeSpan Total { get; set; }

    public CustomerModel Customer { get; set; }
    public PersonModel Person { get; set; }
}
