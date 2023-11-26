namespace TimeBilling.Maui.Mappings;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using GeneratedCode;

using TimeBilling.Maui.Models;

public class ModelMapper : Profile
{
  public ModelMapper() => CreateMap<PersonResponse, Person>();
}
