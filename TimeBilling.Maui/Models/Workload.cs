namespace TimeBilling.Maui.Models
{
    public sealed class Workload
    {
        public int WorkloadId { get; set; }
        public int CustomerId { get; set; }
        public int PersonId { get; set; }
        public DateTimeOffset Begin { get; set; }
        public DateTimeOffset End { get; set; }
        public TimeSpan Total => End - Begin;

        //public Customer? Customer { get; set; }
        //public Person? Person { get; set; }
    }
}
