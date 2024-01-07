namespace TimeBilling.Api.Auth.Endpoints.Users;
using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

using TimeBilling.Api.Auth.Mediators;

public sealed class AcknowledgeUserEndpoint(ISender sender)
  : EndpointBaseAsync
    .WithRequest<AcknowledgeRegistration.AcknowledgeRegistrationRequest>
    .WithActionResult<AcknowledgeRegistration.AcknowledgeRegistrationResponse>
{
  [HttpPost("/auth/users/acknowledge")]
  [SwaggerOperation(Summary = "Acknowledge new user", OperationId = "Auth_Acknowledge", Tags = new[] { "Authentication" })]
  public override async Task<ActionResult<AcknowledgeRegistration.AcknowledgeRegistrationResponse>> HandleAsync([FromBody] AcknowledgeRegistration.AcknowledgeRegistrationRequest request, CancellationToken cancellationToken = default) =>
    await sender.Send(request, cancellationToken);
}
