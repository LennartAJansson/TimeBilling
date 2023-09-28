namespace TimeBilling.Api.Handlers;

using System.Collections.Generic;
using System.Threading.Tasks;

using MediatR;

using TimeBilling.Contracts;
using TimeBilling.Domain.Abstract.Handlers;

public class CustomerHandlers: ICustomerHandlers
{
    //This class assumes there are more todo between the endpoint and mediator
    //Bear with me, I'm trying to keep this simple :)

    private readonly ILogger<CustomerHandlers> logger;
    private readonly IMediator mediator;

    public CustomerHandlers(ILogger<CustomerHandlers> logger, IMediator mediator)
    {
        this.logger = logger;
        this.mediator = mediator;
    }

    public async Task<CustomerResponse?> CreateCustomer(CreateCustomerCommand request)
    {
        CustomerResponse? response = await mediator.Send(request);
        return response;
    }

    public async Task<CustomerResponse?> DeleteCustomer(DeleteCustomerCommand request)
    {
        CustomerResponse? response = await mediator.Send(request);
        return response;
    }

    public async Task<CustomerResponse?> GetCustomer(GetCustomerQuery request)
    {
        CustomerResponse? response = await mediator.Send(request);
        return response;
    }

    public async Task<IEnumerable<CustomerResponse>> GetCustomers(GetCustomersQuery request)
    {
        IEnumerable<CustomerResponse> response = await mediator.Send(request);
        return response;
    }

    public async Task<CustomerResponse?> UpdateCustomer(UpdateCustomerCommand request)
    {
        CustomerResponse? response = await mediator.Send(request);
        return response;
    }
}
