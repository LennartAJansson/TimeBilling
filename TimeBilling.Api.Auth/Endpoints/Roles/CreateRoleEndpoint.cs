namespace TimeBilling.Api.Auth.Endpoints.Roles;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

using TimeBilling.Api.Auth.Mediators;

public sealed class CreateRoleEndpoint(ISender sender)
  : EndpointBaseAsync
    .WithRequest<CreateRole.CreateRoleRequest>
    .WithActionResult<CreateRole.CreateRoleResponse>
{
    [HttpPost("/auth/roles/create")]
    [SwaggerOperation(Summary = "Create new role", OperationId = "Auth_CreateRole", Tags = new[] { "Authentication" })]
    public override async Task<ActionResult<CreateRole.CreateRoleResponse>> HandleAsync([FromBody] CreateRole.CreateRoleRequest request, CancellationToken cancellationToken = default) =>
      await sender.Send(request, cancellationToken);
}
