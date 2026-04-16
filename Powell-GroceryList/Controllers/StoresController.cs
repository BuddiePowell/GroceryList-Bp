using Powell_GroceryList.Services;
using Powell_GroceryList.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Powell_GroceryList.Controllers
{
    public class StoresController : Controller
    {
        private IGroceryRepository _repository;

        public StoresController(IGroceryRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            List<Store> stores = _repository.GetAllStores();

            return View(stores);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AvailableStores = _repository.GetAllStores();
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Store store)
        {
            if (ModelState.IsValid == true)
            {
                // insert the newly added store to the database
                _repository.AddStore(store);

                return RedirectToAction("Index");
            }

            ViewBag.AvailableStores = _repository.GetAllStores();

            return View(store);
        }
    }
}