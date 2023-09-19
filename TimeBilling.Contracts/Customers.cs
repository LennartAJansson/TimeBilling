namespace TimeBilling.Contracts;

using System.Collections.Generic;

using MediatR;

public record CustomerResponse(int CustomerId, string Name);

public record CreateCustomerCommand(string Name) : IRequest<CustomerResponse>;

public record UpdateCustomerCommand(int CustomerId, string Name) : IRequest<CustomerResponse>;

public record DeleteCustomerCommand(int CustomerId) : IRequest<CustomerResponse>
{
    public static DeleteCustomerCommand Create(int id) => new DeleteCustomerCommand(id);
}

public record GetCustomerQuery(int CustomerId) : IRequest<CustomerResponse>
{
    public static GetCustomerQuery Create(int id) => new GetCustomerQuery(id);
}

public record GetCustomersQuery() : IRequest<IEnumerable<CustomerResponse>>
{
    public static GetCustomersQuery Create() => new GetCustomersQuery();
}
