namespace TimeBilling.Api.Domain.Mediators;
using System.Threading.Tasks;

using MediatR;

using Microsoft.Extensions.Logging;

using TimeBilling.Api.Domain.Abstract.Services;
using TimeBilling.Common.Contracts;

public sealed class CustomerApiCommandMediator(ILogger<CustomerApiCommandMediator> logger, IChannelService service) :
    IRequestHandler<CreateCustomerWithIdRequest, CommandResponse>,
    IRequestHandler<UpdateCustomerRequest, CommandResponse>,
    IRequestHandler<DeleteCustomerRequest, CommandResponse>
{
  private readonly ILogger<CustomerApiCommandMediator> logger = logger;
  private readonly IChannelService service = service;

  public async Task<CommandResponse> Handle(CreateCustomerWithIdRequest request, CancellationToken cancellationToken)
  {
    CommandResponse response = await service.CreateCustomer(request);
    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }
    return response;
  }

  public async Task<CommandResponse> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
  {
    CommandResponse response = await service.UpdateCustomer(request);
    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }
    return response;
  }

  public async Task<CommandResponse> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
  {
    CommandResponse response = await service.DeleteCustomer(request);
    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }
    return response;
  }
}

