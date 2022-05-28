using Microsoft.AspNetCore.Mvc;
using ProductionLibrary;
using ProductionManager_EndProject.Models;
using ProductionManager_EndProject.Repositories;
using System;
using System.Threading.Tasks;

namespace ProductionManager_EndProject.Controllers
{
    public class LotController : Controller
    {
        private readonly LotRepository _lotRepository;
        private readonly ProductRepository _productRepository;

        public LotController(LotRepository lotRepository, ProductRepository productRepository)
        {
            _lotRepository = lotRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            LotIndexOverviewModel vm = new LotIndexOverviewModel();
            vm.Lots = _lotRepository.GetAll();
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int roomId, int productionId)
        {
            if (roomId == 0 || productionId == 0)
            {
                return NotFound();
            }
            LotCreateOverviewModel vm = new LotCreateOverviewModel(_productRepository);
            vm.RoomId = roomId;
            vm.ProductionId = productionId;
            return View("Create", vm);
        }


        [HttpPost]
        public async Task<IActionResult> Create(LotCreateOverviewModel model)
        {
            if (!ModelState.IsValid || model.RoomId == 0 || model.ProductId == 0)
            {
                //I can't understand why the model somehow "remember" the roomId after coming back here (in case of invalid model & model reseting),
                //but ask me to explicitly give back the productionId... Microsoft Black Magic...
                int magicNumber = model.ProductionId;
                model = new LotCreateOverviewModel(_productRepository); //We do this to repopulate the select items and here we should "forget" the roomId but Microsoft do some magic and after going back to the view the model "remember" the roomId...
                model.ProductionId = magicNumber;
                return View("Create", model);
            }
            Lot lot = new Lot();
            lot.RoomId = model.RoomId;
            lot.ProductId = (int)model.ProductId;
            lot.Description = model.Description;
            lot.StartDate = DateTime.Now;
            lot.EstimatedQuantitie = double.Parse(model.EstimatedQuantitie);
            lot.IsGrowing = true;
            lot.ProductName = await _productRepository.GetNameById((int)model.ProductId);
            lot.Reference = SetReference(lot.ProductName, lot.StartDate);
            lot.UnitType = await _productRepository.GetUnitTypeById((int)model.ProductId);

            await _lotRepository.Create(lot);

            return RedirectToAction("MainPage", "Production", new { id = model.ProductionId});
        }


        [NonAction]
        private string SetReference(string productName, DateTime startDate)
        {
            string reference = "";
            string[] date = startDate.ToString().Split(" ");


            if (productName.Length > 4)
            {
                for (int i = 0; i < 3; i++)
                {
                    reference += char.ToUpper(productName[i]);
                }
                reference += productName[productName.Length - 1];
            }
            else
            {
                reference += productName[0];
            }

            reference += date[0].Replace("/", "") + '-';
            reference += date[1].Replace(':', '0');
            
            return reference;
        }

        [HttpGet]
        public async Task<IActionResult> Collect(int lotId, int productionId)
        {

            if (lotId == 0 || productionId == 0)
            {
                return NotFound();
            }

            LotCollectOverviewModel vm = new LotCollectOverviewModel();
            vm.LotId = lotId;
            vm.ProductionId = productionId;

            return View(vm);


        }

        [HttpPost]
        public async Task<IActionResult> Collect(LotCollectOverviewModel model)
        {
            if (!ModelState.IsValid)
            {
                //How to show custom error without cleaning ?

                ModelState.Clear();
                ModelState.AddModelError(nameof(model.Collected), "U need to use a positive or negative number");
                return View(model);
            }
            Lot lot = await _lotRepository.GetById(model.LotId);
            lot.RecoltedQuantitie = (double)(lot.RecoltedQuantitie + model.Collected);
            if (lot.RecoltedQuantitie < 0)
            {
                lot.RecoltedQuantitie = 0;
            }

            await _lotRepository.Update(lot);

            return RedirectToAction("MainPage", "Production", new { id = model.ProductionId});


        }

        [HttpGet]
        public async Task<IActionResult> Delete(int lotId, int productionId)
        {
            if (lotId == 0 || productionId == 0)
            {
                return NotFound();
            }
            LotDeleteOverviewModel vm = new LotDeleteOverviewModel();
            vm.LotId = lotId;
            vm.ProductionId = productionId;

            return View(vm);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(LotDeleteOverviewModel model)
        {
            if (model.LotId == 0 || model.ProductionId == 0 || model == null)
            {
                return NotFound();
            }
            Lot lot = await _lotRepository.DeleteById(model.LotId);
            if (lot == null)
            {
                return NotFound();
            }
            return RedirectToAction("MainPage", "Production", new {id = model.ProductionId});
        }
    }
}
