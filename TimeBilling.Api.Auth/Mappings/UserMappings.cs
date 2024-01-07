namespace TimeBilling.Api.Auth.Mappings;

using AutoMapper;

using TimeBilling.Api.Auth.Contracts;
using TimeBilling.Api.Auth.Data.Model;

using static TimeBilling.Api.Auth.Mediators.AcknowledgeRegistration;
using static TimeBilling.Api.Auth.Mediators.LoginUser;
using static TimeBilling.Api.Auth.Mediators.LogoutUser;
using static TimeBilling.Api.Auth.Mediators.RegisterUser;

internal class UserMappings : Profile
{
  public UserMappings()
  {
    _ = CreateMap<AuthUser, RegisterUserResponse>()
        .ForCtorParam("Email", opt => opt.MapFrom(u => u.Email));

    _ = CreateMap<AuthLogin, LoginUserResponse>()
        .ForCtorParam("Id", opt => opt.MapFrom(u => u.Id))
        .ForCtorParam("UserName", opt => opt.MapFrom(u => u.UserName))
        .ForCtorParam("Roles", opt => opt.MapFrom(u => u.Roles))
        .ForCtorParam("Jwt", opt => opt.MapFrom(u => u.Jwt));

    _ = CreateMap<AuthUser, LogoutUserResponse>()
        .ForCtorParam("Email", opt => opt.MapFrom(u => u.Email));

    _ = CreateMap<AuthUser, AcknowledgeRegistrationResponse>()
        .ForCtorParam("Email", opt => opt.MapFrom(u => u.Email));
  }
}
