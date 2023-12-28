namespace TimeBilling.Api.Domain.Abstract.Services;

using System.Threading.Tasks;

using TimeBilling.Common.Contracts;

public interface IChannelService
{
  Task<CommandResponse> CreateCustomer(CreateCustomerWithIdRequest request);
  Task<CommandResponse> CreatePerson(CreatePersonWithIdRequest request);
  Task<CommandResponse> CreateWorkload(CreateWorkloadWithIdRequest request);
  Task<CommandResponse> DeleteCustomer(DeleteCustomerRequest request);
  Task<CommandResponse> DeletePerson(DeletePersonRequest request);
  Task<CommandResponse> DeleteWorkload(DeleteWorkloadRequest request);
  Task<CommandResponse> UpdateCustomer(UpdateCustomerRequest request);
  Task<CommandResponse> UpdatePerson(UpdatePersonRequest request);
  Task<CommandResponse> UpdateWorkload(UpdateWorkloadRequest request);
}
