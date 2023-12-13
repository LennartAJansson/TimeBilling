namespace TimeBilling.Contracts;
using System;
using System.Collections.Generic;

public record CustomerResponse(int CustomerId, string Name, IEnumerable<WorkloadResponse> Workloads)
{
  public static CustomerResponse Create(int id, string name, IEnumerable<WorkloadResponse> workloads) => new(id, name, workloads);
}

public record PersonResponse(int PersonId, string Name, IEnumerable<WorkloadResponse> Workloads)
{
  public static PersonResponse Create(int id, string name, IEnumerable<WorkloadResponse> workloads) => new(id, name, workloads);
}

public record WorkloadResponse(int WorkloadId, DateTimeOffset Begin, DateTimeOffset? End, PersonResponse? Person, CustomerResponse? Customer)
{
  public TimeSpan Total => End.HasValue ? End.Value - Begin : DateTimeOffset.Now - Begin;
  public static WorkloadResponse Create(int id, DateTimeOffset begin, DateTimeOffset? end, PersonResponse? person, CustomerResponse? customer) => new(id, begin, end, person, customer);
}

