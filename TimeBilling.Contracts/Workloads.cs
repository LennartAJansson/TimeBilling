namespace TimeBilling.Contracts;

using MediatR;

public record WorkloadResponse(int WorkloadId, DateTimeOffset Begin, DateTimeOffset? End, PersonResponse Person, CustomerResponse Customer)
{
  public TimeSpan Total => End.HasValue ? End.Value - Begin : DateTimeOffset.Now - Begin;
}

public record BeginWorkloadCommand(DateTimeOffset Begin, int PersonId, int CustomerId) : IRequest<WorkloadResponse>;

public record EndWorkloadCommand(int WorkloadId, DateTimeOffset End) : IRequest<WorkloadResponse>;

public record DeleteWorkloadCommand(int WorkloadId) : IRequest<WorkloadResponse>
{
  public static DeleteWorkloadCommand Create(int id) => new(id);
}

public record GetWorkloadQuery(int WorkloadId) : IRequest<WorkloadResponse>
{
  public static GetWorkloadQuery Create(int id) => new(id);
}

public record GetWorkloadsQuery() : IRequest<IEnumerable<WorkloadResponse>>
{
  public static GetWorkloadsQuery Create() => new();
}

public record GetWorkloadsByCustomerQuery(int CustomerId) : IRequest<IEnumerable<WorkloadResponse>>
{
  public static GetWorkloadsByCustomerQuery Create(int id) => new(id);
}

public record GetWorkloadsByPersonQuery(int PersonId) : IRequest<IEnumerable<WorkloadResponse>>
{
  public static GetWorkloadsByPersonQuery Create(int id) => new(id);
}


