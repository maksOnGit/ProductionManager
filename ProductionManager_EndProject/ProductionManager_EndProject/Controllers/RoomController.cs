using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductionLibrary;
using ProductionManager_EndProject.Models;
using ProductionManager_EndProject.Repositories;
using System.Threading.Tasks;

namespace ProductionManager_EndProject.Controllers
{
    public class RoomController : Controller
    {
        private readonly RoomRepository _roomRepository;
        private readonly UserManager<User> _userManager;


        public RoomController(RoomRepository roomRepository, UserManager<User> userManager)
        {
            _roomRepository = roomRepository;
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> Create(int productionId) 
        {
            Room room = new Room();
            room.ProductionId = productionId;

            return View(room);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Room room)
        {

            if (ModelState.IsValid)
            {
                var result = await _roomRepository.Create(room);
                if (result != null)
                {

                    return RedirectToAction("MainPage", "Production", new { id = room.ProductionId});
                }
                ModelState.AddModelError(nameof(room.RoomName), "U already have a unit with this name");
            }
            return View(room);
        }


        
        [HttpGet]    
        public async Task<IActionResult> Delete(int id, int prodId)
        {
            DeleteRoomOverviewModel vm = new DeleteRoomOverviewModel();
            vm.RoomId = id;
            vm.ProductionId = prodId;
            return View(vm);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(DeleteRoomOverviewModel vm)
        {
            var target = await _roomRepository.DeleteById(vm.RoomId);
            return RedirectToAction("MainPage", "Production", new {id = target.ProductionId});

        }
    }
}
