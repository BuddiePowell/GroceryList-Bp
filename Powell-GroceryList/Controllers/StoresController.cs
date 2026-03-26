using Powell_GroceryList.Services;
using Powell_GroceryList.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Powell_GroceryList.Controllers
{
    public class StoresController : Controller
    {
        private GroceryDatabaseContext _databaseContext;

        public StoresController(GroceryDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IActionResult Index()
        {
            List<Store> stores = _databaseContext.GetAllStores();

            return View(stores);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AvailableStores = _databaseContext.GetAllStores();
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Store store)
        {
            if (ModelState.IsValid == true)
            {
                // insert the newly added store to the database
                _databaseContext.AddStore(store);

                return RedirectToAction("Index");
            }

            ViewBag.AvailableStores = _databaseContext.GetAllStores();

            return View(store);
        }
    }
}