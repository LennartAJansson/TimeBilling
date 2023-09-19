namespace TimeBilling.Domain.Mediators;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using TimeBilling.Contracts;
using TimeBilling.Domain.Abstract;
using TimeBilling.Model;

public class WorkloadMediator :
    IRequestHandler<GetWorkloadsQuery, IEnumerable<WorkloadResponse>>,
    IRequestHandler<GetWorkloadsByCustomerQuery, IEnumerable<WorkloadResponse>>,
    IRequestHandler<GetWorkloadsByPersonQuery, IEnumerable<WorkloadResponse>>,
    IRequestHandler<GetWorkloadQuery, WorkloadResponse>,
    IRequestHandler<BeginWorkloadCommand, WorkloadResponse>,
    IRequestHandler<EndWorkloadCommand, WorkloadResponse?>,
    IRequestHandler<DeleteWorkloadCommand, WorkloadResponse>
{
    private readonly ILogger<WorkloadMediator> logger;
    private readonly IMapper mapper;
    private readonly ITimeBillingService service;

    public WorkloadMediator(ILogger<WorkloadMediator> logger, IMapper mapper, ITimeBillingService service)
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

    public async Task<WorkloadResponse> Handle(BeginWorkloadCommand request, CancellationToken cancellationToken)
    {
        Workload workload = mapper.Map<Workload>(request);
        Workload result = await service.BeginWorkload(workload);
        WorkloadResponse response = mapper.Map<WorkloadResponse>(result);

        return response;
    }

    public async Task<WorkloadResponse?> Handle(EndWorkloadCommand request, CancellationToken cancellationToken)
    {
        Workload? workload = await service.ReadWorkload(request.WorkloadId);
        if (workload is null) 
        {
            return null;
        }

        workload.End = request.End;
        Workload? result = await service.EndWorkload(workload);
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
