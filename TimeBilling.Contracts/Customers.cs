namespace TimeBilling.Contracts;

using System.Collections.Generic;

using MediatR;

public record CustomerResponse(int CustomerId, string Name, IEnumerable<WorkloadResponse> Workloads)
{
  public static CustomerResponse Create(int id, string name, IEnumerable<WorkloadResponse> workloads) => new(id, name, workloads);
}

public record CreateCustomerCommand(string Name) : IRequest<CustomerResponse>
{
  public static CreateCustomerCommand Create(string name) => new(name);
}

public record UpdateCustomerCommand(int CustomerId, string Name) : IRequest<CustomerResponse>
{
  public static UpdateCustomerCommand Create(int id, string name) => new(id, name);
}

public record DeleteCustomerCommand(int CustomerId) : IRequest<CustomerResponse>
{
  public static DeleteCustomerCommand Create(int id) => new(id);
}

public record GetCustomerQuery(int CustomerId) : IRequest<CustomerResponse>
{
  public static GetCustomerQuery Create(int id) => new(id);
}

public record GetCustomersQuery() : IRequest<IEnumerable<CustomerResponse>>
{
  public static GetCustomersQuery Create() => new();
}
