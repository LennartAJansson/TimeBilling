namespace TimeBilling.Api.Domain.Handlers;

using MediatR;

using Microsoft.Extensions.Logging;

using TimeBilling.Api.Domain.Abstract.Handlers;
using TimeBilling.Common.Contracts;

public sealed class WorkloadsHandler(ILogger<WorkloadsHandler> logger, IMediator mediator) : IWorkloadsHandler
{
  private readonly ILogger<WorkloadsHandler> logger = logger;
  private readonly IMediator mediator = mediator;

  public async Task<CommandResponse?> CreateWorkload(CreateWorkloadRequest request)
  {
    CommandResponse? response = await mediator.Send(CreateWorkloadWithIdRequest.Create(Guid.NewGuid(), request.Begin, request.PersonId, request.CustomerId));
    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }
    return response;
  }

  public async Task<CommandResponse?> UpdateWorkload(UpdateWorkloadRequest request)
  {
    CommandResponse? response = await mediator.Send(request);
    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }
    return response;
  }

  public async Task<CommandResponse?> DeleteWorkload(DeleteWorkloadRequest request)
  {
    CommandResponse? response = await mediator.Send(request);
    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }
    return response;
  }

  public async Task<WorkloadResponse?> GetWorkload(GetWorkloadRequest request)
  {
    WorkloadResponse? response = await mediator.Send(request);
    return response;
  }

  public async Task<IEnumerable<WorkloadResponse>> GetWorkloads(GetWorkloadsRequest request)
  {
    IEnumerable<WorkloadResponse> response = await mediator.Send(request);
    return response;
  }

  public async Task<IEnumerable<WorkloadResponse>> GetWorkloadsByCustomer(GetWorkloadsByCustomerRequest request)
  {
    IEnumerable<WorkloadResponse> response = await mediator.Send(request);
    return response;
  }

  public async Task<IEnumerable<WorkloadResponse>> GetWorkloadsByPerson(GetWorkloadsByPersonRequest request)
  {
    IEnumerable<WorkloadResponse> response = await mediator.Send(request);
    return response;
  }
}
