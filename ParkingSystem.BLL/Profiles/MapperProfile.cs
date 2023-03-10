using AutoMapper;
using ParkingSystem.DAL.Models;
using ParkingSystem.DTO.CustomerModule;
using ParkingSystem.DTO.ParkingSlotModule;

namespace ParkingSystem.BLL.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();

            CreateMap<ParkingSlot, ParkingSlotDTO>().ReverseMap();


        }
    }
}
