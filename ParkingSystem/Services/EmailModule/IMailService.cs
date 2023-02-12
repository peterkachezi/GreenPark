

using ParkingSystem.DTO.ApplicationUsersModule;

namespace ParkingSystem.Services.EmailModule
{
    public interface IMailService
    {

        bool PasswordResetEmailNotification(ResetPasswordDTO resetPasswordDTO);
        bool AccountEmailNotification(ApplicationUserDTO applicationUserDTO);

    }
}