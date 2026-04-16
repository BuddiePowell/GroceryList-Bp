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
        private IGroceryRepository _repository;
        

        public GroceriesController(IGroceryRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()

        {
            List<GroceryItem> groceryItems = _repository.GetAllGroceryItems();

            return View(groceryItems);
        }

        [HttpGet]

        public IActionResult Create()
        {
            ViewBag.AvailableStores = _repository.GetAllStores();

            return View();
        }

        [HttpPost]
        public IActionResult Create(GroceryItem groceryItem)
        {
            if (ModelState.IsValid == true)
            {
                // insert the grocery items into the database
                _repository.AddGroceryItem(groceryItem);


                return RedirectToAction("Index");
            }

            ViewBag.AvailableStores = _repository.GetAllStores();

            return View(groceryItem);
        }
    }
}
