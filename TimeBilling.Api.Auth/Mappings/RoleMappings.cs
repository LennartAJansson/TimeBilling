namespace TimeBilling.Api.Auth.Mappings;

using AutoMapper;

using TimeBilling.Api.Auth.Data.Model;

using static TimeBilling.Api.Auth.Mediators.CreateRole;
using static TimeBilling.Api.Auth.Mediators.DeleteRole;

public class RoleMappings : Profile
{
  public RoleMappings()
  {
    _ = CreateMap<AuthRole, CreateRoleResponse>()
        .ForCtorParam("RoleName", opt => opt.MapFrom(r => r.Name));

    _ = CreateMap<AuthRole, DeleteRoleResponse>()
        .ForCtorParam("RoleName", opt => opt.MapFrom(r => r.Name));
  }
}
