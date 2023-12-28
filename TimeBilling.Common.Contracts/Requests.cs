namespace TimeBilling.Common.Contracts;
using System;

using MediatR;

public sealed record CreateCustomerRequest(string Name)
{
  public static CreateCustomerRequest Create(string name) => new(name);
}

public sealed record CreateCustomerWithIdRequest(Guid CustomerId, string Name) : IRequest<CommandResponse>
{
  public static CreateCustomerWithIdRequest Create(Guid id, string name) => new(id, name);
}

public sealed record GetCustomerRequest(Guid CustomerId) : IRequest<CustomerResponse>
{
  public static GetCustomerRequest Create(Guid id) => new(id);
}

public sealed record GetCustomersRequest() : IRequest<IEnumerable<CustomerResponse>>
{
  public static GetCustomersRequest Create() => new();
}

public sealed record UpdateCustomerRequest(Guid CustomerId, string Name) : IRequest<CommandResponse>
{
  public static UpdateCustomerRequest Create(Guid id, string name) => new(id, name);
}

public sealed record DeleteCustomerRequest(Guid CustomerId) : IRequest<CommandResponse>
{
  public static DeleteCustomerRequest Create(Guid id) => new(id);
}

public sealed record CreatePersonRequest(string Name)
{
  public static CreatePersonRequest Create(string name) => new(name);
}

public sealed record CreatePersonWithIdRequest(Guid PersonId, string Name) : IRequest<CommandResponse>
{
  public static CreatePersonWithIdRequest Create(Guid id, string name) => new(id, name);
}

public sealed record GetPersonRequest(Guid PersonId) : IRequest<PersonResponse>
{
  public static GetPersonRequest Create(Guid id) => new(id);
}

public sealed record GetPeopleRequest() : IRequest<IEnumerable<PersonResponse>>
{
  public static GetPeopleRequest Create() => new();
}

public sealed record UpdatePersonRequest(Guid PersonId, string Name) : IRequest<CommandResponse>
{
  public static UpdatePersonRequest Create(Guid id, string name) => new(id, name);
}

public sealed record DeletePersonRequest(Guid PersonId) : IRequest<CommandResponse>
{
  public static DeletePersonRequest Create(Guid id) => new(id);
}

public sealed record CreateWorkloadRequest(DateTimeOffset Begin, Guid PersonId, Guid CustomerId)
{
  public static CreateWorkloadRequest Create(DateTimeOffset begin, Guid personId, Guid customerId) => new(begin, personId, customerId);
}

public sealed record CreateWorkloadWithIdRequest(Guid WorkloadId, DateTimeOffset Begin, Guid PersonId, Guid CustomerId) : IRequest<CommandResponse>
{
  public static CreateWorkloadWithIdRequest Create(Guid id, DateTimeOffset begin, Guid personId, Guid customerId) => new(id, begin, personId, customerId);
}

public sealed record GetWorkloadRequest(Guid WorkloadId) : IRequest<WorkloadResponse>
{
  public static GetWorkloadRequest Create(Guid id) => new(id);
}

public sealed record GetWorkloadsRequest() : IRequest<IEnumerable<WorkloadResponse>>
{
  public static GetWorkloadsRequest Create() => new();
}

public sealed record GetWorkloadsByCustomerRequest(Guid CustomerId) : IRequest<IEnumerable<WorkloadResponse>>
{
  public static GetWorkloadsByCustomerRequest Create(Guid id) => new(id);
}

public sealed record GetWorkloadsByPersonRequest(Guid PersonId) : IRequest<IEnumerable<WorkloadResponse>>
{
  public static GetWorkloadsByPersonRequest Create(Guid id) => new(id);
}

public sealed record UpdateWorkloadRequest(Guid WorkloadId, DateTimeOffset End) : IRequest<CommandResponse>
{
  public static UpdateWorkloadRequest Create(Guid id, DateTimeOffset end) => new(id, end);
}

public sealed record DeleteWorkloadRequest(Guid WorkloadId) : IRequest<CommandResponse>
{
  public static DeleteWorkloadRequest Create(Guid id) => new(id);
}


