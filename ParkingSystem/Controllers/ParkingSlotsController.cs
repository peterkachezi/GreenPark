using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ParkingSystem.BLL.Repositories.CustomerModule;
using ParkingSystem.BLL.Repositories.ParkingSlotModule;
using ParkingSystem.DAL.Models;
using ParkingSystem.DTO.CustomerModule;
using ParkingSystem.DTO.ParkingSlotModule;

namespace ParkingSystem.Controllers
{
	public class ParkingSlotsController : Controller
	{
        private readonly IParkingSlotRepository parkingSlotRepository;

        private readonly UserManager<AppUser> userManager;
        public ParkingSlotsController(UserManager<AppUser> userManager, IParkingSlotRepository parkingSlotRepository)
        {
            this.parkingSlotRepository = parkingSlotRepository;

            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var customers = await parkingSlotRepository.GetAll();

                return View(customers);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<IActionResult> Create(ParkingSlotDTO parkingSlotDTO)
        {
            try
            {
                parkingSlotDTO.Name = parkingSlotDTO.Name.Substring(0, 1).ToUpper() + parkingSlotDTO.Name.Substring(1).ToLower().Trim();

                var user = await userManager.FindByEmailAsync(User.Identity.Name);

                parkingSlotDTO.CreatedBy = user.Id;

                var results = await parkingSlotRepository.Create(parkingSlotDTO);

                if (results != null)
                {
                    return Json(new { success = true, responseText = "Slot has been successfully created" });
                }
                else
                {
                    return Json(new { success = false, responseText = "Failed to create record" });
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return Json(new { success = false, responseText = "Something went wrong" });
            }
        }
        public async Task<IActionResult> Update(ParkingSlotDTO parkingSlotDTO)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(User.Identity.Name);

                parkingSlotDTO.Name = parkingSlotDTO.Name.Substring(0, 1).ToUpper() + parkingSlotDTO.Name.Substring(1).ToLower().Trim();

                parkingSlotDTO.UpdatedBy = user.Id;

                var results = await parkingSlotRepository.Update(parkingSlotDTO);

                if (results != null)
                {
                    return Json(new { success = true, responseText = "Slot details has been successfully updated" });
                }
                else
                {
                    return Json(new { success = false, responseText = "Failed to update record!" });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return Json(new { success = false, responseText = "Something went wrong" });
            }
        }
        public async Task<ActionResult> Delete(Guid Id)
        {
            try
            {
                var results = await parkingSlotRepository.Delete(Id);

                if (results == true)
                {
                    return Json(new { success = true, responseText = "Record  has been successfully deleted " });
                }
                else
                {
                    return Json(new { success = false, responseText = "Record has not been deleted ,it could be in use by other files" });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return Json(new { success = false, responseText = "Something went wrong" });
            }
        }
        public async Task<IActionResult> GetById(Guid Id)
        {
            try
            {
                var file = await parkingSlotRepository.GetById(Id);

                if (file != null)
                {
                    return Json(new { data = file });
                }

                return Json(new { data = false });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return Json(new { success = false, responseText = "Something went wrong" });
            }
        }
    }
}
