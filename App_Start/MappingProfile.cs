using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Arcade.Dtos;
using Arcade.Models;
using AutoMapper;

namespace Arcade.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>().ReverseMap();

        }
    }
}