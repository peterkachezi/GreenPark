using System.ComponentModel.DataAnnotations;
namespace ParkingSystem.DTO.ApplicationUsersModule
{
    public class LoginDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RemeberMe { get; set; }

    }
}
