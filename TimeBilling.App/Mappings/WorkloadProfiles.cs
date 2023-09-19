namespace TimeBilling.Domain.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using TimeBilling.Contracts;
using TimeBilling.App.Models;

public class WorkloadProfiles : Profile
{
    public WorkloadProfiles()
    {
        CreateMap<WorkloadResponse, WorkloadModel>();
        //CreateMap<WorkloadModel, WorkloadResponse>()
        //    .ForCtorParam("WorkloadId", options => options.MapFrom("Id"));
        //CreateMap<BeginWorkloadCommand, WorkloadModel>();
        ////TODO! Fix all mappings! Shouldn't map, lookup and modify EndTime
        //CreateMap<EndWorkloadCommand, WorkloadModel>();
    }
}
