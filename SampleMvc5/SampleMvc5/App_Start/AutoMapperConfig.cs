using AutoMapper;
using SampleMvc5.Dtos;
using SampleMvc5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMvc5.App_Start
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper { get; set; }
        public static void Init()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDto>();
                //.ForMember(dst => dst.Id, src => src.MapFrom(y => y.Id));
            });

            Mapper = config.CreateMapper();
            //CreateMap<Customer, CustomerDto>().ReverseMap();
            //CreateMap<Customer, CustomerDto>();
            //CreateMap<CustomerDto, Customer>();
        
        }
    }
}