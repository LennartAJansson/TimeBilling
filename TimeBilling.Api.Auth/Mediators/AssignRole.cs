namespace TimeBilling.Api.Auth.Mediators;
using System.Threading.Tasks;

using MediatR;

using TimeBilling.Api.Auth.Data.Model;
using TimeBilling.Api.Auth.Services;

public sealed class AssignRole(IApiAuthService service)
  : IRequestHandler<AssignRole.AssignRoleRequest, AssignRole.AssignRoleResponse>
{
  public record AssignRoleRequest(string Email, string RoleName)
    : IRequest<AssignRoleResponse>
  {
    public static AssignRoleRequest Create(string email, string roleName) =>
      new(email, roleName);
  }

  public record AssignRoleResponse(string Email, string RoleName)
  {
    public static AssignRoleResponse Create(string email, string roleName) =>
      new(email, roleName);
  }

  public async Task<AssignRoleResponse> Handle(AssignRoleRequest request, CancellationToken cancellationToken)
  {
    AuthRole role = await service.AssignRole(request.Email, request.RoleName);

    return AssignRoleResponse.Create(request.Email, role.Name!);
  }
}

