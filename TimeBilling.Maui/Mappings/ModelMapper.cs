namespace TimeBilling.Maui.Mappings;

using AutoMapper;

using TimeBilling.Contracts;
using TimeBilling.Maui.Models;

public class ModelMapper : Profile
{
  public ModelMapper()
  {
    _ = CreateMap<PersonResponse, Person>();
    _ = CreateMap<Person, CreatePersonCommand>();
    _ = CreateMap<Person, UpdatePersonCommand>();

    _ = CreateMap<CustomerResponse, Customer>();
    _ = CreateMap<Customer, CreateCustomerCommand>();
    _ = CreateMap<Customer, UpdateCustomerCommand>();

    _ = CreateMap<WorkloadResponse, Workload>();
    _ = CreateMap<Workload, BeginWorkloadCommand>();
    _ = CreateMap<Workload, EndWorkloadCommand>();
  }
}
