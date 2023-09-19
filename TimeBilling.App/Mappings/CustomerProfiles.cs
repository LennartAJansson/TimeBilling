namespace TimeBilling.App.Mappings;

using AutoMapper;

using TimeBilling.Contracts;
using TimeBilling.App.Models;

public class CustomerProfiles : Profile
{
    public CustomerProfiles()
    {
        CreateMap<CustomerResponse, CustomerModel>();
        //CreateMap<CustomerModel, CustomerResponse>()
        //    .ForCtorParam("CustomerId", options => options.MapFrom("Id"));
        //CreateMap<CreateCustomerCommand, CustomerModel>();
        ////TODO! Fix all mappings! UpdateCustomerCommand.CustomerId maps to Customer.Id
        //CreateMap<UpdateCustomerCommand, CustomerModel>();
    }
}
