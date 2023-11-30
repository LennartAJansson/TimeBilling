namespace TimeBilling.Maui.Services;

using AutoMapper;

using GeneratedCode;

public class WorkloadService : IWorkloadService
{
  private readonly ITimeBillingApi api;
  private readonly IMapper mapper;

  public WorkloadService(ITimeBillingApi api, IMapper mapper)
  {
    this.api = api;
    this.mapper = mapper;
  }
}