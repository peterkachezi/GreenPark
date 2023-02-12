

using ParkingSystem.DTO.ApplicationUsersModule;

namespace ParkingSystem.Services.SMSModule
{
    public interface IMessagingService
    {
        Task<ApplicationUserDTO> usersAccount(ApplicationUserDTO applicationUserDTO);

    }
}