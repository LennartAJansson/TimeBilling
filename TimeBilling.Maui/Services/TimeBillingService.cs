using AutoMapper;

using GeneratedCode;

using TimeBilling.Maui.Models;

namespace TimeBilling.Maui.Services
{
    public class TimeBillingService : ITimeBillingService
    {
        private readonly ITimeBillingApi api;
        private readonly IMapper mapper;

        public TimeBillingService(ITimeBillingApi api, IMapper mapper)
        {
            this.api = api;
            this.mapper = mapper;
        }

        public async Task<ICollection<Person>> GetPeople()
        {
            var peopleResponse = await api.GetPeople();

            var result = peopleResponse.Select(p=>mapper.Map<Person>(p)).ToList();
            
            return result;
        }
    }
}
