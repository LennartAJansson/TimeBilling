namespace TimeBilling.Projector.Domain.Mapping;

using AutoMapper;

using TimeBilling.Common.Messaging.Contracts;
using TimeBilling.Model;

public sealed class CustomerProfiles : Profile
{
  public CustomerProfiles()
  {
    _ = CreateMap<CreateCustomerCommand, Customer>()
        .ForMember("Id", options => options.MapFrom("CustomerId"));

    _ = CreateMap<UpdateCustomerCommand, Customer>()
        .ForMember("Id", options => options.MapFrom("CustomerId"));
  }
}
