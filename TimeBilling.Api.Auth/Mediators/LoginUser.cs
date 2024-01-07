namespace TimeBilling.Api.Auth.Mediators;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using TimeBilling.Api.Auth.Services;

public sealed class LoginUser(IApiAuthService service, IMapper mapper)
  : IRequestHandler<LoginUser.LoginUserRequest, LoginUser.LoginUserResponse>
{
  public record LoginUserRequest(string Email, string Password)
    : IRequest<LoginUserResponse>
  {
    public static LoginUserRequest Create(string email, string password) =>
      new(email, password);
  }

  public record LoginUserResponse(Guid Id, string? UserName, IEnumerable<string> Roles, string Jwt)
  {
    public static LoginUserResponse Create(Guid id, string? userName, IEnumerable<string> roles, string jwt) =>
      new(id, userName, roles, jwt);
  }

  public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken) =>
    mapper.Map<LoginUserResponse>(await service.Login(request.Email, request.Password));
}

