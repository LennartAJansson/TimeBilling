namespace TimeBilling.Domain.Mappings;

using AutoMapper;

using TimeBilling.Contracts;
using TimeBilling.Model;

public class CustomerProfiles : Profile
{
    public CustomerProfiles()
    {
        CreateMap<Customer, CustomerResponse>()
            .ForCtorParam("CustomerId", options => options.MapFrom("Id"));
        CreateMap<CreateCustomerCommand, Customer>();
        //TODO! Fix all mappings! UpdateCustomerCommand.CustomerId maps to Customer.Id
        CreateMap<UpdateCustomerCommand, Customer>();
    }
}
