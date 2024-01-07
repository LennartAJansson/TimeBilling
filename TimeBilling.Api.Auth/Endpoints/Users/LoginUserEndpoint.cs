namespace TimeBilling.Api.Auth.Endpoints.Users;
using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

using TimeBilling.Api.Auth.Mediators;

public sealed class LoginUserEndpoint(ISender sender)
  : EndpointBaseAsync
    .WithRequest<LoginUser.LoginUserRequest>
    .WithActionResult<LoginUser.LoginUserResponse>
{
    [HttpPost("/auth/users/login")]
    [SwaggerOperation(Summary = "Login user", OperationId = "Auth_Login", Tags = new[] { "Authentication" })]
    public override async Task<ActionResult<LoginUser.LoginUserResponse>> HandleAsync([FromBody] LoginUser.LoginUserRequest request, CancellationToken cancellationToken = default) =>
      await sender.Send(request, cancellationToken);
}
