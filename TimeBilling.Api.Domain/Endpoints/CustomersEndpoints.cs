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

public static class CustomersEndpoints
{
  public static IEndpointRouteBuilder AddCustomersEndpoints(this IEndpointRouteBuilder builder)
  {
    RouteGroupBuilder group = builder.MapGroup("Customers").WithTags("Customers");
    _ = group.MapGet("/GetCustomers",
            async Task<Results<Ok<IEnumerable<CustomerResponse>>, NotFound>> ([FromServices] ICustomersHandler handler) =>
            {
              IEnumerable<CustomerResponse>? result = await handler.GetCustomers(GetCustomersRequest.Create());
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
            async Task<Results<Ok<CustomerResponse>, NotFound>> ([FromRoute] Guid customerId, [FromServices] ICustomersHandler handler) =>
            {
              CustomerResponse? result = await handler.GetCustomer(GetCustomerRequest.Create(customerId));
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
            async Task<Results<Ok<CommandResponse>, NotFound>> ([FromBody] CreateCustomerRequest customer, [FromServices] ICustomersHandler handler) =>
            {
              CommandResponse? result = await handler.CreateCustomer(customer);
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
            async Task<Results<Ok<CommandResponse>, NotFound>> ([FromBody] UpdateCustomerRequest customer, [FromServices] ICustomersHandler handler) =>
            {
              CommandResponse? result = await handler.UpdateCustomer(customer);
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
            async Task<Results<Ok<CommandResponse>, NotFound>> ([FromRoute] Guid customerId, [FromServices] ICustomersHandler handler) =>
            {
              CommandResponse? result = await handler.DeleteCustomer(DeleteCustomerRequest.Create(customerId));
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
