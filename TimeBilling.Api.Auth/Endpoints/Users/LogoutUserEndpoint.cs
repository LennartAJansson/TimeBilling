namespace TimeBilling.Api.Auth.Endpoints.Users;
using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

using TimeBilling.Api.Auth.Mediators;

public sealed class LogoutUserEndpoint(ISender sender)
  : EndpointBaseAsync
    .WithRequest<LogoutUser.LogoutUserRequest>
    .WithActionResult<LogoutUser.LogoutUserResponse>
{
    [HttpPost("/auth/users/logout")]
    [SwaggerOperation(Summary = "Logout user", OperationId = "Auth_Logout", Tags = new[] { "Authentication" })]
    public override async Task<ActionResult<LogoutUser.LogoutUserResponse>> HandleAsync([FromBody] LogoutUser.LogoutUserRequest request, CancellationToken cancellationToken = default) =>
      await sender.Send(request, cancellationToken);
}
