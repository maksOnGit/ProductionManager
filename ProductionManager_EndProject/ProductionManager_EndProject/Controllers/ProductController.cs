using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        [Authorize(Roles = "admin, manager, worker")]
        public async Task<IActionResult> Index()
        {
            ProductIndexOverviewModel model = new ProductIndexOverviewModel();
            model.products = _productRepository.GetAll();
            return View(model);
        }
        [Authorize(Roles = "admin, manager")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View("CreateEdit");
        }
        [Authorize(Roles = "admin, manager")]
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

            

            return View("CreateEdit", vm);
        }
        [Authorize(Roles = "admin, manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(CreateEditProductOverviewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateEdit", model);
            }
            Product product = new Product { Id = model.Id,
                                            ProductName = model.ProductName,
                                            ImageUrl = model.ImageUrl,
                                            PriceFor = model.PriceFor,
                                            RealStock = model.RealStock,
                                            Price = (double)model.Price
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
        [Authorize(Roles = "admin, manager")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ProductDeleteOverviewModel vm = new ProductDeleteOverviewModel();
            vm.Id = id;
            return View(vm);
        }
        [Authorize(Roles = "admin, manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ProductDeleteOverviewModel model)
        {
            if (model.Id == 0 || model == null)
            {
                return NotFound();
            }
            Product prod = await _productRepository.DeleteById(model.Id);
            if (prod == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

    }
}
