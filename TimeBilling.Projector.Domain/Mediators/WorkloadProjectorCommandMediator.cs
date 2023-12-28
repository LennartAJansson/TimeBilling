namespace TimeBilling.Projector.Domain.Mediators;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using TimeBilling.Common.Contracts;
using TimeBilling.Common.Messaging.Contracts;
using TimeBilling.Model;
using TimeBilling.Projector.Domain.Abstract.Services;

public sealed class WorkloadProjectorCommandMediator(ILogger<WorkloadProjectorCommandMediator> logger, IMapper mapper, IProjectorPersistanceService service) :
    IRequestHandler<CreateWorkloadCommand, CommandResponse>,
    IRequestHandler<UpdateWorkloadCommand, CommandResponse?>,
    IRequestHandler<DeleteWorkloadCommand, CommandResponse>
{
  private readonly ILogger<WorkloadProjectorCommandMediator> logger = logger;
  private readonly IMapper mapper = mapper;
  private readonly IProjectorPersistanceService service = service;

  public async Task<CommandResponse> Handle(CreateWorkloadCommand request, CancellationToken cancellationToken)
  {
    Workload workload = mapper.Map<Workload>(request);
    Workload result = await service.CreateWorkload(workload);

    CommandResponse response = result is not null ?
      new CommandResponse(true, $"Workload with id: {result.Id} created") :
      new CommandResponse(false, $"Workload with id: {request.WorkloadId} NOT created");

    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }

    return response;
  }

  public async Task<CommandResponse?> Handle(UpdateWorkloadCommand request, CancellationToken cancellationToken)
  {
    Workload? result = await service.UpdateWorkload(request.WorkloadId, request.End);

    CommandResponse response = result is not null ?
      CommandResponse.Create(true, $"Workload with id: {result.Id} updated") :
      CommandResponse.Create(false, $"Workload with id: {request.WorkloadId} NOT updated");

    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }

    return response;
  }

  public async Task<CommandResponse> Handle(DeleteWorkloadCommand request, CancellationToken cancellationToken)
  {
    Workload? result = await service.DeleteWorkload(request.WorkloadId);

    CommandResponse response = result is not null ?
      CommandResponse.Create(true, $"Workload with id: {result.Id} deleted") :
      CommandResponse.Create(false, $"Workload with id: {request.WorkloadId} NOT deleted");

    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }

    return response;
  }
}

