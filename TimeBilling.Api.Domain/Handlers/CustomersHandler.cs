namespace TimeBilling.Api.Domain.Handlers;

using MediatR;

using Microsoft.Extensions.Logging;

using TimeBilling.Api.Domain.Abstract.Handlers;
using TimeBilling.Common.Contracts;

public sealed class CustomersHandler(ILogger<CustomersHandler> logger, IMediator mediator) : ICustomersHandler
{
  private readonly ILogger<CustomersHandler> logger = logger;
  private readonly IMediator mediator = mediator;

  public async Task<CommandResponse?> CreateCustomer(CreateCustomerRequest request)
  {
    CommandResponse? response = await mediator.Send(CreateCustomerWithIdRequest.Create(Guid.NewGuid(), request.Name));
    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }
    return response;
  }

  public async Task<CommandResponse?> UpdateCustomer(UpdateCustomerRequest request)
  {
    CommandResponse? response = await mediator.Send(request);
    return response;
  }

  public async Task<CommandResponse?> DeleteCustomer(DeleteCustomerRequest request)
  {
    CommandResponse? response = await mediator.Send(request);
    return response;
  }

  public async Task<CustomerResponse?> GetCustomer(GetCustomerRequest request)
  {
    CustomerResponse? response = await mediator.Send(request);
    return response;
  }

  public async Task<IEnumerable<CustomerResponse>> GetCustomers(GetCustomersRequest request)
  {
    IEnumerable<CustomerResponse> response = await mediator.Send(request);
    return response;
  }
}
