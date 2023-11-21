using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using TimeBilling.Maui.Models;
using GeneratedCode;

namespace TimeBilling.Maui.Mappings
{
    public class ModelMapper: Profile
    {
        public ModelMapper()
        {
            CreateMap<PersonResponse, Person>();
        }
    }
}
