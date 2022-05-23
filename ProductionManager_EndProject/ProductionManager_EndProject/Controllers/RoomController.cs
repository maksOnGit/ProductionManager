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
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Create(int productionId) // id = productionId
        {
            Room room = new Room();
            room.ProductionId = productionId;
            //ProductionMainPageOverviewModel vm = new ProductionMainPageOverviewModel();


            return View(room);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Room room)
        {

            if (ModelState.IsValid)
            {
                var result = await _roomRepository.Create(room);
                if (result != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(room);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            return null;
        }
    }
}
