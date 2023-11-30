namespace TimeBilling.Maui.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

using TimeBilling.Maui.Models;

public interface IPeopleService
{
  Task<Person> CreatePerson(Person person);
  Task<Person> UpdatePerson(Person person);
  Task<Person> DeletePerson(Person person);
  Task<Person> GetPerson(int id);
  Task<IEnumerable<Person>> GetPeople();
}
