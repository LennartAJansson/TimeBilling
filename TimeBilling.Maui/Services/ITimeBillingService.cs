using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using GeneratedCode;

using TimeBilling.Maui.Models;

namespace TimeBilling.Maui.Services
{
    public interface ITimeBillingService
    {
        Task<ICollection<Person>> GetPeople();
    }
}
