﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductionLibrary;
using ProductionManager_EndProject.Models;
using ProductionManager_EndProject.Repositories;
using System.Threading.Tasks;

namespace ProductionManager_EndProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ProductRepository _productRepository;

        public ProductController(UserManager<User> userManager, ProductRepository productRepository)
        {
            _userManager = userManager;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View("CreateEdit");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            CreateEditProductOverviewModel vm = new CreateEditProductOverviewModel();
            Product product = await _productRepository.GetById(id);
            vm.Id = id;
            vm.ProductName = product.ProductName;
            vm.ImageUrl = product.ImageUrl;
            vm.Price = product.Price;
            vm.PriceFor = product.PriceFor;
            vm.RealStock = product.RealStock;
            vm.OrderedStock = product.OrderedStock;
            vm.NotOrderedStock = product.NotOrderedStock;
            vm.ProductionId = product.ProductionId;
            

            return View("CreateEdit", vm);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEditCompany(CreateEditProductOverviewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateEdit", model);
            }
            Product product = new Product { Id = model.Id,
                                            ProductName = model.ProductName,
                                            ImageUrl = model.ImageUrl,
                                            ProductionId = model.ProductionId,
                                            PriceFor = model.PriceFor,
                                            RealStock = model.RealStock,
                                            OrderedStock = model.OrderedStock,
                                            NotOrderedStock = model.NotOrderedStock,
                                            Price = model.Price
                                           };
            if (model.Id == 0)
            {
                //Create
                await _productRepository.Create(product);
            }
            else
            {
                //Edit
                await _productRepository.Update(product);
            }
            return RedirectToAction("Index");
        }

    }
}
