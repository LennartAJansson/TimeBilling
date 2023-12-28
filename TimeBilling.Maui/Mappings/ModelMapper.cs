namespace TimeBilling.Maui.Mappings;

using AutoMapper;

using TimeBilling.Common.Contracts;
using TimeBilling.Maui.Models;

public class ModelMapper : Profile
{
  public ModelMapper()
  {
    _ = CreateMap<PersonResponse, Person>();
    _ = CreateMap<Person, CreatePersonRequest>();
    _ = CreateMap<Person, UpdatePersonRequest>();

    _ = CreateMap<CustomerResponse, Customer>();
    _ = CreateMap<Customer, CreateCustomerRequest>();
    _ = CreateMap<Customer, UpdateCustomerRequest>();

    _ = CreateMap<WorkloadResponse, Workload>();
    _ = CreateMap<Workload, CreateWorkloadRequest>();
    _ = CreateMap<Workload, UpdateWorkloadRequest>();
  }
}
