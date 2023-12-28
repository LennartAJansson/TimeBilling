namespace TimeBilling.Api.Domain.Mediators;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using TimeBilling.Api.Domain.Abstract.Services;
using TimeBilling.Common.Contracts;
using TimeBilling.Model;

public sealed class WorkloadApiQueryMediator(ILogger<WorkloadApiQueryMediator> logger, IMapper mapper, ITimeBillingQueryService service) :
    IRequestHandler<GetWorkloadsRequest, IEnumerable<WorkloadResponse>>,
    IRequestHandler<GetWorkloadsByCustomerRequest, IEnumerable<WorkloadResponse>>,
    IRequestHandler<GetWorkloadsByPersonRequest, IEnumerable<WorkloadResponse>>,
    IRequestHandler<GetWorkloadRequest, WorkloadResponse>
{
  private readonly ILogger<WorkloadApiQueryMediator> logger = logger;
  private readonly IMapper mapper = mapper;
  private readonly ITimeBillingQueryService service = service;

  public async Task<IEnumerable<WorkloadResponse>> Handle(GetWorkloadsRequest request, CancellationToken cancellationToken)
  {
    IEnumerable<Workload> result = await service.ReadWorkloads();
    IEnumerable<WorkloadResponse> response = result.Select(mapper.Map<WorkloadResponse>);

    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response:\n{response}", string.Join('\n', response));
    }

    return response;
  }

  public async Task<IEnumerable<WorkloadResponse>> Handle(GetWorkloadsByCustomerRequest request, CancellationToken cancellationToken)
  {
    IEnumerable<Workload> result = await service.ReadWorkloadsByCustomer(request.CustomerId);
    IEnumerable<WorkloadResponse> response = result.Select(mapper.Map<WorkloadResponse>);

    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response:\n{response}", string.Join('\n', response));
    }

    return response;
  }

  public async Task<IEnumerable<WorkloadResponse>> Handle(GetWorkloadsByPersonRequest request, CancellationToken cancellationToken)
  {
    IEnumerable<Workload> result = await service.ReadWorkloadsByPerson(request.PersonId);
    IEnumerable<WorkloadResponse> response = result.Select(mapper.Map<WorkloadResponse>);

    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response:\n{response}", string.Join('\n', response));
    }

    return response;
  }

  public async Task<WorkloadResponse> Handle(GetWorkloadRequest request, CancellationToken cancellationToken)
  {
    Workload? result = await service.ReadWorkload(request.WorkloadId);
    WorkloadResponse response = mapper.Map<WorkloadResponse>(result);

    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }

    return response;
  }
}

