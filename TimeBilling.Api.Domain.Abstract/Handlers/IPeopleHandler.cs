namespace TimeBilling.Api.Domain.Abstract.Handlers;

using TimeBilling.Common.Contracts;

public interface IPeopleHandler
{
  Task<CommandResponse?> CreatePerson(CreatePersonRequest request);
  Task<CommandResponse?> UpdatePerson(UpdatePersonRequest request);
  Task<CommandResponse?> DeletePerson(DeletePersonRequest request);
  Task<IEnumerable<PersonResponse>> GetPeople(GetPeopleRequest request);
  Task<PersonResponse?> GetPerson(GetPersonRequest request);
}
