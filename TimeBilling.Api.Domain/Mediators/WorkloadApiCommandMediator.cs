namespace TimeBilling.Api.Domain.Mediators;
using System.Threading.Tasks;

using MediatR;

using Microsoft.Extensions.Logging;

using TimeBilling.Common.Contracts;
using TimeBilling.Common.Messaging.Services;

public sealed class WorkloadApiCommandMediator(ILogger<WorkloadApiCommandMediator> logger, ICommandSender nats) :
    IRequestHandler<CreateWorkloadWithIdRequest, CommandResponse>,
    IRequestHandler<UpdateWorkloadRequest, CommandResponse?>,
    IRequestHandler<DeleteWorkloadRequest, CommandResponse>
{
  public async Task<CommandResponse> Handle(CreateWorkloadWithIdRequest request, CancellationToken cancellationToken)
  {
    CommandResponse response = await nats.SendAsync(request);
    //.CreateWorkload(request);
    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }
    return response;
  }

  public async Task<CommandResponse?> Handle(UpdateWorkloadRequest request, CancellationToken cancellationToken)
  {
    CommandResponse response = await nats.SendAsync(request);
    //.UpdateWorkload(request);
    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }
    return response;
  }

  public async Task<CommandResponse> Handle(DeleteWorkloadRequest request, CancellationToken cancellationToken)
  {
    CommandResponse response = await nats.SendAsync(request);
    //.DeleteWorkload(request);
    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }
    return response;
  }
}

