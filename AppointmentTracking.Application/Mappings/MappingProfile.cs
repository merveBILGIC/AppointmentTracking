using AppointmentTracking.Application.DTOs;
using AppointmentTracking.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTracking.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Consultant, ConsultantDto>().ReverseMap();
            CreateMap<ConsultantProfile, ConsultantProfileDto>().ReverseMap(); 
            CreateMap<Service, ServiceDto>().ReverseMap();
        }
    }
}
