namespace TimeBilling.Api.Auth.Mediators;
using System.Threading.Tasks;

using MediatR;

using TimeBilling.Api.Auth.Data.Model;
using TimeBilling.Api.Auth.Services;

public sealed class RevokeRole(IApiAuthService service)
  : IRequestHandler<RevokeRole.RevokeRoleRequest, RevokeRole.RevokeRoleResponse>
{
  public record RevokeRoleRequest(string Email, string RoleName)
    : IRequest<RevokeRoleResponse>
  {
    public static RevokeRoleRequest Create(string email, string roleName) =>
      new(email, roleName);
  }

  public record RevokeRoleResponse(string Email, string RoleName)
  {
    public static RevokeRoleResponse Create(string email, string roleName) =>
      new(email, roleName);
  }

  public async Task<RevokeRoleResponse> Handle(RevokeRoleRequest request, CancellationToken cancellationToken)
  {
    AuthRole role = await service.RevokeRole(request.Email, request.RoleName);

    return RevokeRoleResponse.Create(request.Email, role.Name!);
  }
}

