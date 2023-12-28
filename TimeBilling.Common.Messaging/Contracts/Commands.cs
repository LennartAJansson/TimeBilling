namespace TimeBilling.Common.Messaging.Contracts;
using System;

using MediatR;

using TimeBilling.Common.Contracts;

public interface ICommand;

public sealed record CreateCustomerCommand(Guid CustomerId, string Name) : IRequest<CommandResponse>, ICommand
{
  public static CreateCustomerCommand Create(CreateCustomerWithIdRequest request) => new(request.CustomerId, request.Name);
}

public sealed record UpdateCustomerCommand(Guid CustomerId, string Name) : IRequest<CommandResponse>, ICommand
{
  public static UpdateCustomerCommand Create(UpdateCustomerRequest request) => new(request.CustomerId, request.Name);
}

public sealed record DeleteCustomerCommand(Guid CustomerId) : IRequest<CommandResponse>, ICommand
{
  public static DeleteCustomerCommand Create(DeleteCustomerRequest request) => new(request.CustomerId);
}

public sealed record CreatePersonCommand(Guid PersonId, string Name) : IRequest<CommandResponse>, ICommand
{
  public static CreatePersonCommand Create(CreatePersonWithIdRequest request) => new(request.PersonId, request.Name);
}

public sealed record UpdatePersonCommand(Guid PersonId, string Name) : IRequest<CommandResponse>, ICommand
{
  public static UpdatePersonCommand Create(UpdatePersonRequest request) => new(request.PersonId, request.Name);
}

public sealed record DeletePersonCommand(Guid PersonId) : IRequest<CommandResponse>, ICommand
{
  public static DeletePersonCommand Create(DeletePersonRequest request) => new(request.PersonId);
}

public sealed record CreateWorkloadCommand(Guid WorkloadId, DateTimeOffset Begin, Guid PersonId, Guid CustomerId) : IRequest<CommandResponse>, ICommand
{
  public static CreateWorkloadCommand Create(CreateWorkloadWithIdRequest request) => new(request.WorkloadId, request.Begin, request.PersonId, request.CustomerId);
}

public sealed record UpdateWorkloadCommand(Guid WorkloadId, DateTimeOffset End) : IRequest<CommandResponse>, ICommand
{
  public static UpdateWorkloadCommand Create(UpdateWorkloadRequest request) => new(request.WorkloadId, request.End);
}

public sealed record DeleteWorkloadCommand(Guid WorkloadId) : IRequest<CommandResponse>, ICommand
{
  public static DeleteWorkloadCommand Create(DeleteWorkloadRequest request) => new(request.WorkloadId);
}


