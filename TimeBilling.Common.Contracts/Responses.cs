namespace TimeBilling.Common.Contracts;
using System;
using System.Collections.Generic;

public sealed record CommandResponse(bool Success, string Message)
{
  public static CommandResponse Create(bool success, string message) => new(success, message);
}


public sealed record CustomerResponse(Guid CustomerId, string Name, IEnumerable<WorkloadResponse> Workloads)
{
  public static CustomerResponse Create(Guid id, string name, IEnumerable<WorkloadResponse> workloads) => new(id, name, workloads);
}

public sealed record PersonResponse(Guid PersonId, string Name, IEnumerable<WorkloadResponse> Workloads)
{
  public static PersonResponse Create(Guid id, string name, IEnumerable<WorkloadResponse> workloads) => new(id, name, workloads);
}

public sealed record WorkloadResponse(Guid WorkloadId, DateTimeOffset Begin, DateTimeOffset? End, PersonResponse? Person, CustomerResponse? Customer)
{
  public TimeSpan Total => End.HasValue ? End.Value - Begin : DateTimeOffset.Now - Begin;
  public static WorkloadResponse Create(Guid id, DateTimeOffset begin, DateTimeOffset? end, PersonResponse? person, CustomerResponse? customer) => new(id, begin, end, person, customer);
}

