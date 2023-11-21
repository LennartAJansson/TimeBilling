using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GeneratedCode;

namespace TimeBilling.Maui.Services
{
    public interface ITimeBillingService
    {
    }

    public class TimeBillingService : ITimeBillingService
    {
        private readonly ITimeBillingApi api;

        public TimeBillingService(ITimeBillingApi api)
        {
            this.api = api;
        }
    }
}
