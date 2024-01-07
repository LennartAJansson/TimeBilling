namespace TimeBilling.Api.Auth.Mediators;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using TimeBilling.Api.Auth.Services;

public sealed class RegisterUser(IApiAuthService service, IMapper mapper)
  : IRequestHandler<RegisterUser.RegisterUserRequest, RegisterUser.RegisterUserResponse>
{
  public record RegisterUserRequest(string Email, string Password, string ConfirmPassword)
    : IRequest<RegisterUserResponse>
  {
    public static RegisterUserRequest Create(string email, string password, string confirmPassword) =>
      new(email, password, confirmPassword);
  }

  public record RegisterUserResponse(string Email)
  {
    public static RegisterUserResponse Create(string email) =>
      new(email);
  }

  public async Task<RegisterUserResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken) =>
    mapper.Map<RegisterUserResponse>(await service.Register(request.Email, request.Password, request.ConfirmPassword));
}

