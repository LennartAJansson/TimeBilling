namespace TimeBilling.Domain.Mediators;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using TimeBilling.Contracts;
using TimeBilling.Domain.Abstract.Services;
using TimeBilling.Model;
public class WorkloadCommandMediator :
    IRequestHandler<CreateWorkloadCommand, WorkloadResponse>,
    IRequestHandler<UpdateWorkloadCommand, WorkloadResponse?>,
    IRequestHandler<DeleteWorkloadCommand, WorkloadResponse>
{
  private readonly ILogger<WorkloadCommandMediator> logger;
  private readonly IMapper mapper;
  private readonly ITimeBillingCommandService service;

  public WorkloadCommandMediator(ILogger<WorkloadCommandMediator> logger, IMapper mapper, ITimeBillingCommandService service)
  {
    this.logger = logger;
    this.mapper = mapper;
    this.service = service;
  }

  public async Task<WorkloadResponse> Handle(CreateWorkloadCommand request, CancellationToken cancellationToken)
  {
    Workload workload = mapper.Map<Workload>(request);
    Workload result = await service.CreateWorkload(workload);
    WorkloadResponse response = mapper.Map<WorkloadResponse>(result);

    return response;
  }

  public async Task<WorkloadResponse?> Handle(UpdateWorkloadCommand request, CancellationToken cancellationToken)
  {
    Workload? result = await service.UpdateWorkload(request.WorkloadId, request.End);
    WorkloadResponse response = mapper.Map<WorkloadResponse>(result);

    return response;
  }

  public async Task<WorkloadResponse> Handle(DeleteWorkloadCommand request, CancellationToken cancellationToken)
  {
    Workload? result = await service.DeleteWorkload(request.WorkloadId);
    WorkloadResponse response = mapper.Map<WorkloadResponse>(result);

    return response;
  }
}
