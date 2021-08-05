using AutoMapper;
using SampleMvc5.Dtos;
using SampleMvc5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMvc5.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            //CreateMap<Customer, CustomerDto>();
            //CreateMap<CustomerDto, Customer>();
        }
    }
}