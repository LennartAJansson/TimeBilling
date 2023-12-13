namespace TimeBilling.Domain.Mappings;

using AutoMapper;

using TimeBilling.Contracts;
using TimeBilling.Model;

public class CustomerProfiles : Profile
{
  public CustomerProfiles()
  {
    _ = CreateMap<Customer, CustomerResponse>()
        .ForCtorParam("CustomerId", options => options.MapFrom(c => c.Id))
        .ForCtorParam("Name", options => options.MapFrom(c => c.Name));

    _ = CreateMap<CreateCustomerCommand, Customer>();

    _ = CreateMap<UpdateCustomerCommand, Customer>()
        .ForMember("Id", options => options.MapFrom("CustomerId"));
  }
}
