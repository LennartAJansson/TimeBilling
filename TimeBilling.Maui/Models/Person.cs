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
}
