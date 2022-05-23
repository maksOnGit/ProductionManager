using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductionLibrary;
using ProductionManager_EndProject.Data;
using ProductionManager_EndProject.Models;
using ProductionManager_EndProject.Repositories;

namespace ProductionManager_EndProject.Controllers
{

    public class ProductionController : Controller
    {
        private readonly ProductionRepository _productionRepository;
        private readonly UserManager<User> _userManager;


        public ProductionController(ProductionRepository productionRepository, UserManager<User> userManager)
        {
            _productionRepository = productionRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Selection()
        {
            ProductionSelectionOverview vm = new ProductionSelectionOverview();
            vm.AvaiableProductions = _productionRepository.GetAll();
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> MainPage(int id)
        {
            Production activeProd = await _productionRepository.GetByIdInclusive(id);
            //ProductionMainPageOverviewModel vm = new ProductionMainPageOverviewModel();
            return View(activeProd);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var x = _productionRepository.GetAll();
            return View(x);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var production = await _productionRepository.GetById(id);
            if (production == null)
            {
                return NotFound();
            }

            return View(production);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Production production)
        {
            if (ModelState.IsValid)
            {
                var result = await _productionRepository.Create(production);
                if (result != null)
                {
                    return RedirectToAction("Selection");
                }
                ModelState.AddModelError(nameof(production.ProductionName), "This name is already used !");
            }
            return View(production);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var production = await _productionRepository.GetById(id);
            if (production == null)
            {
                return NotFound();
            }
            return View(production);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Production production)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _productionRepository.Update(production);
                }
                catch
                {

                    throw;

                }
                return RedirectToAction("Index");
            }
            return View(production);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var production = await _productionRepository.GetById(id);
            if (production == null)
            {
                return NotFound();
            }

            return View(production);
        }

        // POST: Production/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productionRepository.DeleteById(id);
            return RedirectToAction("Index");
        }

    }
}
