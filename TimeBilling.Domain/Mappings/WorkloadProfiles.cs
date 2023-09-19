namespace TimeBilling.Domain.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using TimeBilling.Contracts;
using TimeBilling.Model;

public class WorkloadProfiles : Profile
{
    public WorkloadProfiles()
    {
        CreateMap<Workload, WorkloadResponse>()
            .ForCtorParam("WorkloadId", options => options.MapFrom("Id"));
        CreateMap<BeginWorkloadCommand, Workload>();
        //TODO! Fix all mappings! Shouldn't map, lookup and modify EndTime
        CreateMap<EndWorkloadCommand, Workload>();
    }
}
