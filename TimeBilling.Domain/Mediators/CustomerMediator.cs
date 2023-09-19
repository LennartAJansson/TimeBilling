namespace TimeBilling.Domain.Mediators;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using TimeBilling.Contracts;
using TimeBilling.Domain.Abstract;
using TimeBilling.Model;

public class CustomerMediator :
    IRequestHandler<GetCustomersQuery, IEnumerable<CustomerResponse>>,
    IRequestHandler<GetCustomerQuery, CustomerResponse>,
    IRequestHandler<CreateCustomerCommand, CustomerResponse>,
    IRequestHandler<UpdateCustomerCommand, CustomerResponse>,
    IRequestHandler<DeleteCustomerCommand, CustomerResponse>
{
    private readonly ILogger<CustomerMediator> logger;
    private readonly IMapper mapper;
    private readonly ITimeBillingService service;

    public CustomerMediator(ILogger<CustomerMediator> logger, IMapper mapper, ITimeBillingService service)
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
