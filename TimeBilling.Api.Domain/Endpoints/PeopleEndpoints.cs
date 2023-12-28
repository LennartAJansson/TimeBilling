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

public static class PeopleEndpoints
{
  public static IEndpointRouteBuilder AddPeopleEndpoints(this IEndpointRouteBuilder builder)
  {
    RouteGroupBuilder group = builder.MapGroup("People").WithTags("People");
    _ = group.MapGet("/GetPeople",
            async Task<Results<Ok<IEnumerable<PersonResponse>>, NotFound>> ([FromServices] IPeopleHandler handler) =>
            {
              IEnumerable<PersonResponse>? result = await handler.GetPeople(GetPeopleRequest.Create());
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
            async Task<Results<Ok<PersonResponse>, NotFound>> ([FromRoute] Guid personId, [FromServices] IPeopleHandler handler) =>
            {
              PersonResponse? result = await handler.GetPerson(GetPersonRequest.Create(personId));
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
            async Task<Results<Ok<CommandResponse>, NotFound>> ([FromBody] CreatePersonRequest person, [FromServices] IPeopleHandler handler) =>
            {
              CommandResponse? result = await handler.CreatePerson(person);
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
            async Task<Results<Ok<CommandResponse>, NotFound>> ([FromBody] UpdatePersonRequest person, [FromServices] IPeopleHandler handler) =>
            {
              CommandResponse? result = await handler.UpdatePerson(person);
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
            async Task<Results<Ok<CommandResponse>, NotFound>> ([FromRoute] Guid personId, [FromServices] IPeopleHandler handler) =>
            {
              CommandResponse? result = await handler.DeletePerson(DeletePersonRequest.Create(personId));
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
