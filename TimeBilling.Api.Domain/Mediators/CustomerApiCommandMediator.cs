namespace TimeBilling.Api.Domain.Mediators;
using System.Threading.Tasks;

using MediatR;

using Microsoft.Extensions.Logging;

using TimeBilling.Common.Contracts;
using TimeBilling.Common.Messaging.Services;

public sealed class CustomerApiCommandMediator(ILogger<CustomerApiCommandMediator> logger, ICommandSender nats) :
    IRequestHandler<CreateCustomerWithIdRequest, CommandResponse>,
    IRequestHandler<UpdateCustomerRequest, CommandResponse>,
    IRequestHandler<DeleteCustomerRequest, CommandResponse>
{
  public async Task<CommandResponse> Handle(CreateCustomerWithIdRequest request, CancellationToken cancellationToken)
  {
    CommandResponse response = await nats.SendAsync(request);
    //.CreateCustomer(request);
    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }
    return response;
  }

  public async Task<CommandResponse> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
  {
    CommandResponse response = await nats.SendAsync(request);
    //.UpdateCustomer(request);
    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }
    return response;
  }

  public async Task<CommandResponse> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
  {
    CommandResponse response = await nats.SendAsync(request);
    //.DeleteCustomer(request);
    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }
    return response;
  }
}

