namespace TimeBilling.Domain.Mediators;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using TimeBilling.Contracts;
using TimeBilling.Domain.Abstract.Services;
using TimeBilling.Model;

public class CustomerCommandMediator :
    IRequestHandler<CreateCustomerCommand, CustomerResponse>,
    IRequestHandler<UpdateCustomerCommand, CustomerResponse>,
    IRequestHandler<DeleteCustomerCommand, CustomerResponse>
{
  private readonly ILogger<CustomerCommandMediator> logger;
  private readonly IMapper mapper;
  private readonly ITimeBillingCommandService service;

  public CustomerCommandMediator(ILogger<CustomerCommandMediator> logger, IMapper mapper, ITimeBillingCommandService service)
  {
    this.logger = logger;
    this.mapper = mapper;
    this.service = service;
  }

  public async Task<CustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
  {
    Customer customer = mapper.Map<Customer>(request);
    Customer result = await service.CreateCustomer(customer);
    CustomerResponse response = mapper.Map<CustomerResponse>(result);

    return response;
  }

  public async Task<CustomerResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
  {
    Customer customer = mapper.Map<Customer>(request);
    Customer result = await service.UpdateCustomer(customer);
    CustomerResponse response = mapper.Map<CustomerResponse>(result);

    return response;
  }

  public async Task<CustomerResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
  {
    Customer result = await service.DeleteCustomer(request.CustomerId);
    CustomerResponse response = mapper.Map<CustomerResponse>(result);

    return response;
  }
}
