namespace TimeBilling.Api.Domain.Mediators;
using System.Threading.Tasks;

using MediatR;

using Microsoft.Extensions.Logging;

using TimeBilling.Api.Domain.Abstract.Services;
using TimeBilling.Common.Contracts;

public sealed class WorkloadApiCommandMediator(ILogger<WorkloadApiCommandMediator> logger, IChannelService service) :
    IRequestHandler<CreateWorkloadWithIdRequest, CommandResponse>,
    IRequestHandler<UpdateWorkloadRequest, CommandResponse?>,
    IRequestHandler<DeleteWorkloadRequest, CommandResponse>
{
  private readonly ILogger<WorkloadApiCommandMediator> logger = logger;
  private readonly IChannelService service = service;

  public async Task<CommandResponse> Handle(CreateWorkloadWithIdRequest request, CancellationToken cancellationToken)
  {
    CommandResponse response = await service.CreateWorkload(request);
    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }
    return response;
  }

  public async Task<CommandResponse?> Handle(UpdateWorkloadRequest request, CancellationToken cancellationToken)
  {
    CommandResponse response = await service.UpdateWorkload(request);
    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }
    return response;
  }

  public async Task<CommandResponse> Handle(DeleteWorkloadRequest request, CancellationToken cancellationToken)
  {
    CommandResponse response = await service.DeleteWorkload(request);
    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }
    return response;
  }
}

