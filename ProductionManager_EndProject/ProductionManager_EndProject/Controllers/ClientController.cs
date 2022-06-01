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
using ProductionManager_EndProject.Repositories;

namespace ProductionManager_EndProject.Controllers
{
    [Authorize(Roles = "admin, manager")]
    public class ClientController : Controller
    {
        private readonly ClientRepository _clientRepository;
        private readonly UserManager<User> _userManager;


        public ClientController(ClientRepository clientRepository, UserManager<User> userManager)
        {
            _clientRepository = clientRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var x = _clientRepository.GetAll();
            return View(x);
        }
        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _clientRepository.GetById(id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Client client)
        {
            if (ModelState.IsValid)
            {
                var result = await _clientRepository.Create(client);
                if (result != null)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(nameof(client.ClientId), "This name is already used !");
                return View(client);
            }
            return View(client);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _clientRepository.GetById(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Client client)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _clientRepository.Update(client);
                }
                catch
                {

                    throw;

                }
                return RedirectToAction("Index");
            }
            return View(client);
        }


        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _clientRepository.GetById(id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Production/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _clientRepository.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
