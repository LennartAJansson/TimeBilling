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
using Microsoft.FeatureManagement;
using TimeBilling.Api.Filters;
using TimeBilling.Contracts;

public static class CustomersEndpoints
{
    public static IEndpointRouteBuilder AddCustomersEndpoints(this IEndpointRouteBuilder builder)
    {
        RouteGroupBuilder group = builder.MapGroup("Customers").WithTags("Customers");
        _ = group.MapGet("/GetCustomers",
                async Task<Results<Ok<IEnumerable<CustomerResponse>>, NotFound>> ([FromServices] IMediator mediator) =>
                {
                    IEnumerable<CustomerResponse>? result = await mediator.Send(GetCustomersQuery.Create());
                    return result is null || !result.Any()
                        ? TypedResults.NotFound()
                        : TypedResults.Ok(result);
                })
            .WithName("GetCustomers")
            .WithOpenApi()
            .AddEndpointFilter<TimeBillingFeatureAFilter>()
            .Produces(StatusCodes.Status404NotFound)
            .Produces<CustomerResponse[]>(StatusCodes.Status200OK);

        _ = group.MapGet("/GetCustomer/{customerId}",
                async Task<Results<Ok<CustomerResponse>, NotFound>> ([FromRoute] int customerId, [FromServices] IMediator mediator) =>
                {
                    CustomerResponse? result = await mediator.Send(GetCustomerQuery.Create(customerId));
                    return result is null
                        ? TypedResults.NotFound()
                        : TypedResults.Ok(result);

                })
            .WithName("GetCustomer")
            .WithOpenApi()
            .AddEndpointFilter<TimeBillingFeatureAFilter>()
            .Produces(StatusCodes.Status404NotFound)
            .Produces<CustomerResponse>(StatusCodes.Status200OK);

        _ = group.MapPost("/CreateCustomer",
                async Task<Results<Ok<CustomerResponse>, NotFound>> ([FromBody] CreateCustomerCommand customer, [FromServices] IMediator mediator) =>
                {
                    CustomerResponse? result = await mediator.Send(customer);
                    return result is null
                        ? TypedResults.NotFound()
                        : TypedResults.Ok(result);
                })
            .WithName("CreateCustomer")
            .WithOpenApi()
            .AddEndpointFilter<TimeBillingFeatureAFilter>()
            .Produces(StatusCodes.Status404NotFound)
            .Produces<CustomerResponse>(StatusCodes.Status200OK);

        _ = group.MapPut("/UpdateCustomer",
                async Task<Results<Ok<CustomerResponse>, NotFound>> ([FromBody] UpdateCustomerCommand customer, [FromServices] IMediator mediator) =>
                {
                    CustomerResponse? result = await mediator.Send(customer);
                    return result is null
                        ? TypedResults.NotFound()
                        : TypedResults.Ok(result);
                })
            .WithName("UpdateCustomer")
            .WithOpenApi()
            .AddEndpointFilter<TimeBillingFeatureAFilter>()
            .Produces(StatusCodes.Status404NotFound)
            .Produces<CustomerResponse>(StatusCodes.Status200OK);

        _ = group.MapDelete("/DeleteCustomer/{customerId}",
                async Task<Results<Ok<CustomerResponse>, NotFound>> ([FromRoute] int customerId, [FromServices] IMediator mediator) =>
                {
                    CustomerResponse? result = await mediator.Send(DeleteCustomerCommand.Create(customerId));
                    return result is null
                        ? TypedResults.NotFound()
                        : TypedResults.Ok(result);
                })
            .WithName("DeleteCustomer")
            .WithOpenApi()
            .AddEndpointFilter<TimeBillingFeatureAFilter>()
            .Produces(StatusCodes.Status404NotFound)
            .Produces<CustomerResponse>(StatusCodes.Status200OK);

        return builder;
    }
}
