using AutoMapper;
using CarShopDotNet.Application.Dtos;
using CarShopDotNet.Domain.Entities;

// Mapping Profile is Responsible for Mapping Entities to Dtos and Vice Versa
// It is a Class that Inherits from AutoMapper's Profile Class
// It is Required to Create Mapping Between Entities and Dtos

namespace CarShopDotNet.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarDto>().ReverseMap(); // ReverseMap() is Used to Map Dtos to Entities
            CreateMap<Car, CreateCarDto>().ReverseMap();
            
            CreateMap<Owner, OwnerDto>().ReverseMap(); 
            CreateMap<Owner, CreateOwnerDto>().ReverseMap();
        }
    }
}