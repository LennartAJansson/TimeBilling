namespace TimeBilling.Api.Domain.Mediators;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using TimeBilling.Api.Domain.Abstract.Services;
using TimeBilling.Common.Contracts;
using TimeBilling.Model;

public sealed class CustomerApiQueryMediator(ILogger<CustomerApiQueryMediator> logger, IMapper mapper, ITimeBillingQueryService service) :
    IRequestHandler<GetCustomersRequest, IEnumerable<CustomerResponse>>,
    IRequestHandler<GetCustomerRequest, CustomerResponse>
{
  private readonly ILogger<CustomerApiQueryMediator> logger = logger;
  private readonly IMapper mapper = mapper;
  private readonly ITimeBillingQueryService service = service;

  public async Task<IEnumerable<CustomerResponse>> Handle(GetCustomersRequest request, CancellationToken cancellationToken)
  {
    IEnumerable<Customer> result = await service.ReadCustomers();
    IEnumerable<CustomerResponse> response = result.Select(mapper.Map<CustomerResponse>);

    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response:\n{response}", string.Join('\n', response));
    }

    return response;
  }

  public async Task<CustomerResponse> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
  {
    Customer? result = await service.ReadCustomer(request.CustomerId);
    CustomerResponse response = mapper.Map<CustomerResponse>(result);

    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }

    return response;
  }
}

