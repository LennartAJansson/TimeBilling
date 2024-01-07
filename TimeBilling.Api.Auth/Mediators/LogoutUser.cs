namespace TimeBilling.Api.Auth.Mediators;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using TimeBilling.Api.Auth.Services;

public sealed class LogoutUser(IApiAuthService service, IMapper mapper)
  : IRequestHandler<LogoutUser.LogoutUserRequest, LogoutUser.LogoutUserResponse>
{
  public record LogoutUserRequest(string Email)
    : IRequest<LogoutUserResponse>
  {
    public static LogoutUserRequest Create(string email) =>
      new(email);
  }

  public record LogoutUserResponse(string Email)
  {
    public static LogoutUserResponse Create(string email) =>
      new(email);
  }

  public async Task<LogoutUserResponse> Handle(LogoutUserRequest request, CancellationToken cancellationToken) =>
    mapper.Map<LogoutUserResponse>(await service.Logout(request.Email));
}

