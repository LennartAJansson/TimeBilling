namespace TimeBilling.Api.Auth.Mediators;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using TimeBilling.Api.Auth.Services;

public sealed class CreateRole(IApiAuthService service, IMapper mapper)
  : IRequestHandler<CreateRole.CreateRoleRequest, CreateRole.CreateRoleResponse>
{
  public record CreateRoleRequest(string RoleName)
    : IRequest<CreateRoleResponse>
  {
    public static CreateRoleRequest Create(string roleName) =>
      new(roleName);
  }

  public record CreateRoleResponse(string RoleName)
  {
    public static CreateRoleResponse Create(string roleName) =>
      new(roleName);
  }

  public async Task<CreateRoleResponse> Handle(CreateRoleRequest request, CancellationToken cancellationToken) =>
    mapper.Map<CreateRoleResponse>(await service.CreateRole(request.RoleName));
}

