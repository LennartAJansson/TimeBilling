namespace TimeBilling.Api.Endpoints;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

using TimeBilling.Api.Filters;
using TimeBilling.Contracts;

public static class WorkloadsEndpoints
{
  public static IEndpointRouteBuilder AddWorkloadsEndpoints(this IEndpointRouteBuilder builder)
  {
    RouteGroupBuilder group = builder.MapGroup("/Workloads")
        .WithTags("Workloads");

    _ = group.MapGet("/GetWorkloads",
            async Task<Results<Ok<IEnumerable<WorkloadResponse>>, NotFound>> ([FromServices] IMediator mediator) =>
            {
              IEnumerable<WorkloadResponse>? result = await mediator.Send(GetWorkloadsQuery.Create());
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
            async Task<Results<Ok<WorkloadResponse>, NotFound>> ([FromRoute] int workloadId, [FromServices] IMediator mediator) =>
            {
              WorkloadResponse? result = await mediator.Send(GetWorkloadQuery.Create(workloadId));
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
            async Task<Results<Ok<IEnumerable<WorkloadResponse>>, NotFound>> ([FromRoute] int customerId, [FromServices] IMediator mediator) =>
            {
              IEnumerable<WorkloadResponse>? result = await mediator.Send(GetWorkloadsByCustomerQuery.Create(customerId));
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
            async Task<Results<Ok<IEnumerable<WorkloadResponse>>, NotFound>> ([FromRoute] int personId, [FromServices] IMediator mediator) =>
            {
              IEnumerable<WorkloadResponse>? result = await mediator.Send(GetWorkloadsByPersonQuery.Create(personId));
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
            async Task<Results<Ok<WorkloadResponse>, NotFound>> ([FromBody] CreateWorkloadCommand workload, [FromServices] IMediator mediator) =>
            {
              WorkloadResponse? result = await mediator.Send(workload);
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
            async Task<Results<Ok<WorkloadResponse>, NotFound>> ([FromBody] UpdateWorkloadCommand workload, [FromServices] IMediator mediator) =>
            {
              WorkloadResponse? result = await mediator.Send(workload);
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
            async Task<Results<Ok<WorkloadResponse>, NotFound>> ([FromRoute] int workloadId, [FromServices] IMediator mediator) =>
            {
              WorkloadResponse? result = await mediator.Send(DeleteWorkloadCommand.Create(workloadId));
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
