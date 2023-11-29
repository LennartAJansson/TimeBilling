namespace TimeBilling.Maui.Mappings;

using AutoMapper;

using TimeBilling.Contracts;
using TimeBilling.Maui.Models;

public class ModelMapper : Profile
{
  public ModelMapper()
  {
    _ = CreateMap<PersonResponse, Person>();
    _ = CreateMap<Person, UpdatePersonCommand>();
  }
}
