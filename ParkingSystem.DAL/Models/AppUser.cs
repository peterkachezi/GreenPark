using Microsoft.AspNetCore.Identity;


namespace ParkingSystem.DAL.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreatedBy { get; set; }
        public bool isActive { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
