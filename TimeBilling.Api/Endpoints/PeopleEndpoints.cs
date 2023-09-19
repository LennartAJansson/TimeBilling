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

public static class PeopleEndpoints
{
    public static IEndpointRouteBuilder AddPeopleEndpoints(this IEndpointRouteBuilder builder)
    {
        RouteGroupBuilder group = builder.MapGroup("People").WithTags("People");
        _ = group.MapGet("/GetPeople",
                async Task<Results<Ok<IEnumerable<PersonResponse>>, NotFound>> ([FromServices] IMediator mediator) =>
                {
                    var result = await mediator.Send(GetPeopleQuery.Create());
                    return result is null || !result.Any()
                        ? TypedResults.NotFound()
                        : TypedResults.Ok(result);
                })
            .WithName("GetPeople")
            .WithOpenApi()
            .AddEndpointFilter<TimeBillingFeatureAFilter>()
            .Produces(StatusCodes.Status404NotFound)
            .Produces<PersonResponse[]>(StatusCodes.Status200OK);

        _ = group.MapGet("/GetPerson/{personId}",
                async Task<Results<Ok<PersonResponse>, NotFound>> ([FromRoute] int personId, [FromServices] IMediator mediator) =>
                {
                    var result = await mediator.Send(GetPersonQuery.Create(personId));
                    return result is null
                        ? TypedResults.NotFound()
                        : TypedResults.Ok(result);
                })
            .WithName("GetPerson")
            .WithOpenApi()
            .AddEndpointFilter<TimeBillingFeatureAFilter>()
            .Produces(StatusCodes.Status404NotFound)
            .Produces<PersonResponse>(StatusCodes.Status200OK);

        _ = group.MapPost("/CreatePerson",
                async Task<Results<Ok<PersonResponse>, NotFound>> ([FromBody] CreatePersonCommand person, [FromServices] IMediator mediator) =>
                {
                    var result = await mediator.Send(person);
                    return result is null
                        ? TypedResults.NotFound()
                        : TypedResults.Ok(result);
                })
            .WithName("CreatePerson")
            .WithOpenApi()
            .AddEndpointFilter<TimeBillingFeatureAFilter>()
            .Produces(StatusCodes.Status404NotFound)
            .Produces<PersonResponse>(StatusCodes.Status200OK);

        _ = group.MapPut("/UpdatePerson",
                async Task<Results<Ok<PersonResponse>, NotFound>> ([FromBody] UpdatePersonCommand person, [FromServices] IMediator mediator) =>
                {
                    var result = await mediator.Send(person);
                    return result is null
                        ? TypedResults.NotFound()
                        : TypedResults.Ok(result);
                })
            .WithName("UpdatePerson")
            .WithOpenApi()
            .AddEndpointFilter<TimeBillingFeatureAFilter>()
            .Produces(StatusCodes.Status404NotFound)
            .Produces<PersonResponse>(StatusCodes.Status200OK);

        _ = group.MapDelete("/DeletePerson/{personId}",
                async Task<Results<Ok<PersonResponse>, NotFound>> ([FromRoute] int personId, [FromServices] IMediator mediator) =>
                {
                    var result = await mediator.Send(DeletePersonCommand.Create(personId));
                    return result is null
                        ? TypedResults.NotFound()
                        : TypedResults.Ok(result);
                })
            .WithName("DeletePerson")
            .WithOpenApi()
            .AddEndpointFilter<TimeBillingFeatureAFilter>()
            .Produces(StatusCodes.Status404NotFound)
            .Produces<PersonResponse>(StatusCodes.Status200OK);

        return builder;
    }
}
