namespace TimeBilling.Api.Domain.Endpoints;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

using TimeBilling.Api.Domain.Abstract.Handlers;
using TimeBilling.Api.Domain.Filters;
using TimeBilling.Common.Contracts;

public static class WorkloadsEndpoints
{
  public static IEndpointRouteBuilder AddWorkloadsEndpoints(this IEndpointRouteBuilder builder)
  {
    RouteGroupBuilder group = builder.MapGroup("/Workloads")
        .WithTags("Workloads");

    _ = group.MapGet("/GetWorkloads",
            async Task<Results<Ok<IEnumerable<WorkloadResponse>>, NotFound>> ([FromServices] IWorkloadsHandler handler) =>
            {
              IEnumerable<WorkloadResponse>? result = await handler.GetWorkloads(GetWorkloadsRequest.Create());
              return result is null || !result.Any()
                      ? TypedResults.NotFound()
                      : TypedResults.Ok(result);
            })
        .WithName("GetWorkloads")
        .WithOpenApi()
        .AddEndpointFilter<TimeBillingFeatureAFilter>()
        .Produces(StatusCodes.Status404NotFound)
        .Produces<WorkloadResponse[]>(StatusCodes.Status200OK);

    _ = group.MapGet("/GetWorkload/{workloadId}",
            async Task<Results<Ok<WorkloadResponse>, NotFound>> ([FromRoute] Guid workloadId, [FromServices] IWorkloadsHandler handler) =>
            {
              WorkloadResponse? result = await handler.GetWorkload(GetWorkloadRequest.Create(workloadId));
              return result is null
                      ? TypedResults.NotFound()
                      : TypedResults.Ok(result);
            })
        .WithName("GetWorkload")
        .WithOpenApi()
        .AddEndpointFilter<TimeBillingFeatureAFilter>()
        .Produces(StatusCodes.Status404NotFound)
        .Produces<WorkloadResponse>(StatusCodes.Status200OK);

    _ = group.MapGet("/GetWorkloadsByCustomer/{customerId}",
            async Task<Results<Ok<IEnumerable<WorkloadResponse>>, NotFound>> ([FromRoute] Guid customerId, [FromServices] IWorkloadsHandler handler) =>
            {
              IEnumerable<WorkloadResponse>? result = await handler.GetWorkloadsByCustomer(GetWorkloadsByCustomerRequest.Create(customerId));
              return result is null || !result.Any()
                      ? TypedResults.NotFound()
                      : TypedResults.Ok(result);
            })
        .WithName("GetWorkloadsByCustomer")
        .WithOpenApi()
        .AddEndpointFilter<TimeBillingFeatureAFilter>()
        .Produces(StatusCodes.Status404NotFound)
        .Produces<WorkloadResponse[]>(StatusCodes.Status200OK);

    _ = group.MapGet("/GetWorkloadsByPerson/{personId}",
            async Task<Results<Ok<IEnumerable<WorkloadResponse>>, NotFound>> ([FromRoute] Guid personId, [FromServices] IWorkloadsHandler handler) =>
            {
              IEnumerable<WorkloadResponse>? result = await handler.GetWorkloadsByPerson(GetWorkloadsByPersonRequest.Create(personId));
              return result is null || !result.Any()
                      ? TypedResults.NotFound()
                      : TypedResults.Ok(result);
            })
        .WithName("GetWorkloadsByPerson")
        .WithOpenApi()
        .AddEndpointFilter<TimeBillingFeatureAFilter>()
        .Produces(StatusCodes.Status404NotFound)
        .Produces<WorkloadResponse[]>(StatusCodes.Status200OK);

    _ = group.MapPost("/CreateWorkload",
            async Task<Results<Ok<CommandResponse>, NotFound>> ([FromBody] CreateWorkloadRequest workload, [FromServices] IWorkloadsHandler handler) =>
            {
              CommandResponse? result = await handler.CreateWorkload(workload);
              return result is null
                      ? TypedResults.NotFound()
                      : TypedResults.Ok(result);
            })
        .WithName("CreateWorkload")
        .WithOpenApi()
        .AddEndpointFilter<TimeBillingFeatureAFilter>()
        .Produces(StatusCodes.Status404NotFound)
        .Produces<WorkloadResponse>(StatusCodes.Status200OK);

    _ = group.MapPut("/UpdateWorkload",
            async Task<Results<Ok<CommandResponse>, NotFound>> ([FromBody] UpdateWorkloadRequest workload, [FromServices] IWorkloadsHandler handler) =>
            {
              CommandResponse? result = await handler.UpdateWorkload(workload);
              return result is null
                      ? TypedResults.NotFound()
                      : TypedResults.Ok(result);
            })
        .WithName("UpdateWorkload")
        .WithOpenApi()
        .AddEndpointFilter<TimeBillingFeatureAFilter>()
        .Produces(StatusCodes.Status404NotFound)
        .Produces<WorkloadResponse>(StatusCodes.Status200OK);

    _ = group.MapDelete("/DeleteWorkload/{workloadId}",
            async Task<Results<Ok<CommandResponse>, NotFound>> ([FromRoute] Guid workloadId, [FromServices] IWorkloadsHandler handler) =>
            {
              CommandResponse? result = await handler.DeleteWorkload(DeleteWorkloadRequest.Create(workloadId));
              return result is null
                      ? TypedResults.NotFound()
                      : TypedResults.Ok(result);
            })
        .WithName("DeleteWorkload")
        .WithOpenApi()
        .AddEndpointFilter<TimeBillingFeatureAFilter>()
        .Produces(StatusCodes.Status404NotFound)
        .Produces<WorkloadResponse>(StatusCodes.Status200OK);

    return builder;
  }
}
