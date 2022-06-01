using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductionLibrary;
using ProductionManager_EndProject.Models;
using ProductionManager_EndProject.Repositories;
using System.Threading.Tasks;

namespace ProductionManager_EndProject.Controllers
{

    [Authorize(Roles = "admin, manager, worker")]
    public class ProdTaskController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly ProdTaskRepository _prodTaskRepository;
        private readonly ProdTaskUserRepository _prodTaskUserRepository;
        private readonly UserRepository _userRepository;

        public ProdTaskController(UserRepository userRepository, UserManager<User> userManager, ProdTaskRepository prodTaskRepository, ProdTaskUserRepository prodTaskUserRepository)
        {
            _userManager = userManager;
            _prodTaskRepository = prodTaskRepository;
            _prodTaskUserRepository = prodTaskUserRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Create(int productionId)
        {
            ProdTaskCreateOverviewModel vm = new ProdTaskCreateOverviewModel();
            vm.ProductionId = productionId;
            return View("Create", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProdTaskCreateOverviewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", model);
            }
            ProdTask prodTask = new ProdTask
            {
                TaskName = model.TaskName,
                TaskDescription = model.TaskDescription,
                ProductionId = model.ProductionId,
                ProdTaskStatusId = 1
            };

            await _prodTaskRepository.Create(prodTask);
            return RedirectToAction("Missions", "Production", new { id = model.ProductionId });
        }

        public async Task<IActionResult> AssignProdTask(int id, int productionId)
        {
            if (id == 0 || productionId == 0)
            {
                return NotFound();
            }
            ProdTask prodTask = await _prodTaskRepository.GetById(id);
            if (prodTask != null)
            {
                if (prodTask.ProdTaskStatusId != 2)
                {
                    prodTask.ProdTaskStatusId = 2;
                    await _prodTaskRepository.Update(prodTask);
                }
                //Create ProdTaskUsers

                ProdTaskUser prodTaskUser = new ProdTaskUser
                {
                    ProdTaskId = id,
                    UserId = _userManager.GetUserId(User),
                    UserName = _userManager.GetUserName(User)
                };

                //Need to use this one to get entity Id before deleting it
                ProdTaskUser tester = await _prodTaskUserRepository.Exist(prodTaskUser);

                if (tester == null)
                {
                    await _prodTaskUserRepository.Create(prodTaskUser);
                }
                else
                {
                    await _prodTaskUserRepository.Delete(tester);
                    if (await _prodTaskUserRepository.ExistByTaskId(id) == false)
                    {
                        prodTask.ProdTaskStatusId = 1;
                        await _prodTaskRepository.Update(prodTask);
                    }
                }
                return RedirectToAction("Missions", "Production", new { id = productionId });

            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> FinishTask(int id, int productionId)
        {
            if (id == 0 || productionId == 0)
            {
                return NotFound();
            }
            ProdTaskFinishOverviewModel vm = new ProdTaskFinishOverviewModel();
            vm.Id = id;
            vm.ProductionId = productionId;
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> FinishTask(ProdTaskFinishOverviewModel model)
        {
            ProdTask prodTask = await _prodTaskRepository.GetById(model.Id);
            if (prodTask != null)
            {
                prodTask.ProdTaskStatusId = 3;
                await _prodTaskRepository.Update(prodTask);
                return RedirectToAction("Missions", "Production", new { id = model.ProductionId });
            }
            return NotFound();
        }

        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> TaskVerified(int id, int productionId)
        {
            var task = await _prodTaskRepository.GetById(id);
            if (task != null)
            {
                task.ProductionId = null;
                var taskConfirmation = await _prodTaskRepository.Update(task);
                if (taskConfirmation != null)
                {
                    ViewBag.Confirmation = "This ticket was successfully archived";
                    return RedirectToAction("ManagerPanel", "Production", new {id = productionId});
                }
            }
            return NotFound();
        }
    }
}
