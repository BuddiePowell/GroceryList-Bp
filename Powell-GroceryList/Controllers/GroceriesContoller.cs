using Powell_GroceryList.Services;
using Powell_GroceryList.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Powell_GroceryList.Controllers
{
    public class GroceriesController : Controller
    {
        private GroceryDatabaseContext _databaseContext;
        

        public GroceriesController(GroceryDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public IActionResult Index()

        {
            List<GroceryItem> groceryItems = _databaseContext.GetAllGroceryItems();

            return View(groceryItems);
        }

        [HttpGet]

        public IActionResult Create()
        {
            ViewBag.AvailableStores = _databaseContext.GetAllStores();

            return View();
        }

        [HttpPost]
        public IActionResult Create(GroceryItem groceryItem)
        {
            if (ModelState.IsValid == true)
            {
                // insert the grocery items into the database
                _databaseContext.AddGroceryItem(groceryItem);


                return RedirectToAction("Index");
            }

            ViewBag.AvailableStores = _databaseContext.GetAllStores();

            return View(groceryItem);
        }
    }
}
