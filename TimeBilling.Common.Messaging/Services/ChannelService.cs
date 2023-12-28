namespace TimeBilling.Common.Messaging.Services;

using System.Threading.Channels;
using System.Threading.Tasks;

using TimeBilling.Api.Domain.Abstract.Services;
using TimeBilling.Common.Contracts;
using TimeBilling.Common.Messaging.Contracts;

public sealed class ChannelService(Channel<ICommand> channel) : IChannelService
{
  private readonly Channel<ICommand> channel = channel;

  public async Task<CommandResponse> CreateCustomer(CreateCustomerWithIdRequest request)
  {

    await channel.Writer.WriteAsync(CreateCustomerCommand.Create(request));

    return new CommandResponse(true, $"Created customer {request.CustomerId}");
  }

  public async Task<CommandResponse> CreatePerson(CreatePersonWithIdRequest request)
  {
    await channel.Writer.WriteAsync(CreatePersonCommand.Create(request));

    return new CommandResponse(true, $"Created person {request.PersonId}");
  }

  public async Task<CommandResponse> CreateWorkload(CreateWorkloadWithIdRequest request)
  {
    await channel.Writer.WriteAsync(CreateWorkloadCommand.Create(request));

    return new CommandResponse(true, $"Created workload {request.WorkloadId}");
  }

  public async Task<CommandResponse> UpdateCustomer(UpdateCustomerRequest request)
  {
    await channel.Writer.WriteAsync(UpdateCustomerCommand.Create(request));

    return new CommandResponse(true, $"Updated customer {request.CustomerId}");
  }

  public async Task<CommandResponse> UpdatePerson(UpdatePersonRequest request)
  {
    await channel.Writer.WriteAsync(UpdatePersonCommand.Create(request));

    return new CommandResponse(true, $"Updated person {request.PersonId}");
  }

  public async Task<CommandResponse> UpdateWorkload(UpdateWorkloadRequest request)
  {
    await channel.Writer.WriteAsync(UpdateWorkloadCommand.Create(request));

    return new CommandResponse(true, $"Updated workload {request.WorkloadId}");
  }

  public async Task<CommandResponse> DeleteCustomer(DeleteCustomerRequest request)
  {
    await channel.Writer.WriteAsync(DeleteCustomerCommand.Create(request));

    return new CommandResponse(true, $"Deleted customer {request.CustomerId}");
  }

  public async Task<CommandResponse> DeletePerson(DeletePersonRequest request)
  {
    await channel.Writer.WriteAsync(DeletePersonCommand.Create(request));

    return new CommandResponse(true, $"Deleted person {request.PersonId}");
  }

  public async Task<CommandResponse> DeleteWorkload(DeleteWorkloadRequest request)
  {
    await channel.Writer.WriteAsync(DeleteWorkloadCommand.Create(request));

    return new CommandResponse(true, $"Deleted workload {request.WorkloadId}");
  }
}
