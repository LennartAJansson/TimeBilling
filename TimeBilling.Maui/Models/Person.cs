using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeBilling.Maui.Models
{
    public sealed class Person
    {
        public int PersonId { get; set; }
        public required string Name { get; set; }
    }
    public sealed class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
    }

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
