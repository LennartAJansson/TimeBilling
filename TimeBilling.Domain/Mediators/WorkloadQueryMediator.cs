namespace TimeBilling.Domain.Mediators;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using TimeBilling.Contracts;
using TimeBilling.Domain.Abstract.Services;
using TimeBilling.Model;

public class WorkloadQueryMediator :
    IRequestHandler<GetWorkloadsQuery, IEnumerable<WorkloadResponse>>,
    IRequestHandler<GetWorkloadsByCustomerQuery, IEnumerable<WorkloadResponse>>,
    IRequestHandler<GetWorkloadsByPersonQuery, IEnumerable<WorkloadResponse>>,
    IRequestHandler<GetWorkloadQuery, WorkloadResponse>
{
  private readonly ILogger<WorkloadQueryMediator> logger;
  private readonly IMapper mapper;
  private readonly ITimeBillingQueryService service;

  public WorkloadQueryMediator(ILogger<WorkloadQueryMediator> logger, IMapper mapper, ITimeBillingQueryService service)
  {
    this.logger = logger;
    this.mapper = mapper;
    this.service = service;
  }

  public async Task<IEnumerable<WorkloadResponse>> Handle(GetWorkloadsQuery request, CancellationToken cancellationToken)
  {
    IEnumerable<Workload> result = await service.ReadWorkloads();
    IEnumerable<WorkloadResponse> response = result.Select(w => mapper.Map<WorkloadResponse>(w));

    return response;
  }

  public async Task<IEnumerable<WorkloadResponse>> Handle(GetWorkloadsByCustomerQuery request, CancellationToken cancellationToken)
  {
    IEnumerable<Workload> result = await service.ReadWorkloadsByCustomer(request.CustomerId);
    IEnumerable<WorkloadResponse> response = result.Select(w => mapper.Map<WorkloadResponse>(w));

    return response;
  }

  public async Task<IEnumerable<WorkloadResponse>> Handle(GetWorkloadsByPersonQuery request, CancellationToken cancellationToken)
  {
    IEnumerable<Workload> result = await service.ReadWorkloadsByPerson(request.PersonId);
    IEnumerable<WorkloadResponse> response = result.Select(w => mapper.Map<WorkloadResponse>(w));

    return response;
  }

  public async Task<WorkloadResponse> Handle(GetWorkloadQuery request, CancellationToken cancellationToken)
  {
    Workload? result = await service.ReadWorkload(request.WorkloadId);
    WorkloadResponse response = mapper.Map<WorkloadResponse>(result);

    return response;
  }
}
