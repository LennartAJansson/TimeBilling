namespace TimeBilling.Api.Auth.Endpoints.Roles;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

using TimeBilling.Api.Auth.Mediators;

public sealed class DeleteRoleEndpoint(ISender sender)
  : EndpointBaseAsync
    .WithRequest<DeleteRole.DeleteRoleRequest>
    .WithActionResult<DeleteRole.DeleteRoleResponse>
{
    [HttpPost("/auth/roles/delete")]
    [SwaggerOperation(Summary = "Delete role", OperationId = "Auth_DeleteRole", Tags = new[] { "Authentication" })]
    public override async Task<ActionResult<DeleteRole.DeleteRoleResponse>> HandleAsync([FromBody] DeleteRole.DeleteRoleRequest request, CancellationToken cancellationToken = default) =>
      await sender.Send(request, cancellationToken);
}
