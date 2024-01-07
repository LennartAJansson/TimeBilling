namespace TimeBilling.Api.Auth.Endpoints.Roles;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

using TimeBilling.Api.Auth.Mediators;

public sealed class RevokeRoleEndpoint(ISender sender)
  : EndpointBaseAsync
    .WithRequest<RevokeRole.RevokeRoleRequest>
    .WithActionResult<RevokeRole.RevokeRoleResponse>
{
    [HttpPost("/auth/roles/revoke")]
    [SwaggerOperation(Summary = "Revoke role from user", OperationId = "Auth_RevokeRole", Tags = new[] { "Authentication" })]
    public override async Task<ActionResult<RevokeRole.RevokeRoleResponse>> HandleAsync([FromBody] RevokeRole.RevokeRoleRequest request, CancellationToken cancellationToken = default) =>
      await sender.Send(request, cancellationToken);
}
