namespace TimeBilling.Api.Auth.Mediators;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using TimeBilling.Api.Auth.Services;

public sealed class AcknowledgeRegistration(IApiAuthService service, IMapper mapper)
  : IRequestHandler<AcknowledgeRegistration.AcknowledgeRegistrationRequest, AcknowledgeRegistration.AcknowledgeRegistrationResponse>
{
  public record AcknowledgeRegistrationRequest(string Email)
    : IRequest<AcknowledgeRegistrationResponse>
  {
    public static AcknowledgeRegistrationRequest Create(string email) =>
      new(email);
  }

  public record AcknowledgeRegistrationResponse(string Email)
  {
    public static AcknowledgeRegistrationResponse Create(string email) =>
      new(email);
  }

  public async Task<AcknowledgeRegistrationResponse> Handle(AcknowledgeRegistrationRequest request, CancellationToken cancellationToken) =>
    mapper.Map<AcknowledgeRegistrationResponse>(await service.AcknowledgeRegistration(request.Email));
}

