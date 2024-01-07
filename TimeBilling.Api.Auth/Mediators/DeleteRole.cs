namespace TimeBilling.Api.Auth.Mediators;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using TimeBilling.Api.Auth.Services;

public sealed class DeleteRole(IApiAuthService service, IMapper mapper)
  : IRequestHandler<DeleteRole.DeleteRoleRequest, DeleteRole.DeleteRoleResponse>
{
  public record DeleteRoleRequest(string RoleName)
    : IRequest<DeleteRoleResponse>
  {
    public static DeleteRoleRequest Create(string roleName) =>
      new(roleName);
  }

  public record DeleteRoleResponse(string RoleName)
  {
    public static DeleteRoleResponse Create(string roleName) =>
      new(roleName);
  }

  public async Task<DeleteRoleResponse> Handle(DeleteRoleRequest request, CancellationToken cancellationToken) =>
    mapper.Map<DeleteRoleResponse>(await service.DeleteRole(request.RoleName));
}

