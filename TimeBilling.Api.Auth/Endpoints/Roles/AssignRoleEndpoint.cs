namespace TimeBilling.Api.Auth.Endpoints.Roles;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

using TimeBilling.Api.Auth.Mediators;

public sealed class AssignRoleEndpoint(ISender sender)
  : EndpointBaseAsync
    .WithRequest<AssignRole.AssignRoleRequest>
    .WithActionResult<AssignRole.AssignRoleResponse>
{
  [HttpPost("/auth/roles/assign")]
  [SwaggerOperation(Summary = "Assign role to user", OperationId = "Auth_AssignRole", Tags = new[] { "Authentication" })]
  public override async Task<ActionResult<AssignRole.AssignRoleResponse>> HandleAsync([FromBody] AssignRole.AssignRoleRequest request, CancellationToken cancellationToken = default) =>
    await sender.Send(request, cancellationToken);
}
