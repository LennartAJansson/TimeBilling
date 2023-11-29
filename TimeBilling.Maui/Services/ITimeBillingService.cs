namespace TimeBilling.Maui.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

using TimeBilling.Maui.Models;

public interface ITimeBillingService
{
  Task<ICollection<Person>> GetPeople();
  Task UpdatePerson(Person? selectedPerson);
}
