using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ParkingSystem.DAL.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ParkingSystem.Extensions
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<AppUser, IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options)
            : base(userManager, roleManager, options)
        {

        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            identity.AddClaim(new Claim("UserFirstName", user.FirstName ?? ""));

            return identity;
        }


    }

}
