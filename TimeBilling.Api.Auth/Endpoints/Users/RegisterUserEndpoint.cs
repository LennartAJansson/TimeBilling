namespace TimeBilling.Api.Auth.Endpoints.Users;
using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

using TimeBilling.Api.Auth.Mediators;

public sealed class RegisterUserEndpoint(ISender sender)
  : EndpointBaseAsync
    .WithRequest<RegisterUser.RegisterUserRequest>
    .WithActionResult<RegisterUser.RegisterUserResponse>
{
    [HttpPost("/auth/users/register")]
    [SwaggerOperation(Summary = "Register new user", OperationId = "Auth_Register", Tags = new[] { "Authentication" })]
    public override async Task<ActionResult<RegisterUser.RegisterUserResponse>> HandleAsync([FromBody] RegisterUser.RegisterUserRequest request, CancellationToken cancellationToken = default) =>
      await sender.Send(request, cancellationToken);
}
