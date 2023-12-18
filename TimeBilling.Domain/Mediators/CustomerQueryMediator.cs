namespace TimeBilling.Domain.Mediators;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using TimeBilling.Contracts;
using TimeBilling.Domain.Abstract.Services;
using TimeBilling.Model;

//TODO: Explore https://www.linkedin.com/posts/milan-jovanovic_what-are-channels-in-net-channels-are-activity-7138437075728584704-IruR?utm_source=share&utm_medium=member_desktop

public class CustomerQueryMediator:
    IRequestHandler<GetCustomersQuery, IEnumerable<CustomerResponse>>,
    IRequestHandler<GetCustomerQuery, CustomerResponse>
{
  private readonly ILogger<CustomerQueryMediator> logger;
  private readonly IMapper mapper;
  private readonly ITimeBillingQueryService service;

  public CustomerQueryMediator(ILogger<CustomerQueryMediator> logger, IMapper mapper, ITimeBillingQueryService service)
  {
    this.logger = logger;
    this.mapper = mapper;
    this.service = service;
  }

  public async Task<IEnumerable<CustomerResponse>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
  {
    IEnumerable<Customer> result = await service.ReadCustomers();
    IEnumerable<CustomerResponse> response = result.Select(c => mapper.Map<CustomerResponse>(c));

    return response;
  }

  public async Task<CustomerResponse> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
  {
    Customer? result = await service.ReadCustomer(request.CustomerId);
    CustomerResponse response = mapper.Map<CustomerResponse>(result);

    return response;
  }
}
