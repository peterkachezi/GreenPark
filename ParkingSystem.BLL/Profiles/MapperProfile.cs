using AutoMapper;
using ParkingSystem.DAL.Models;
using ParkingSystem.DTO.CustomerModule;

namespace ParkingSystem.BLL.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();


        }
    }
}
