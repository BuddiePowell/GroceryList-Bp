using Powell_GroceryList.Database;
using Microsoft.AspNetCore.Mvc;
using Powell_GroceryList.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Powell_GroceryList.Services;


namespace Powell_GroceryList.Controllers
{
    public class GroceriesController : Controller
    {
        private GroceryDatabaseContext _DatabaseContext;

        public GroceriesController(GroceryDatabaseContext databaseContext)
        {
            _DatabaseContext = databaseContext;
        }
        public IActionResult Index()

        {
            List<GroceryItem> groceryItems = _DatabaseContext.GetAllGroceryItems();

            return View(groceryItems);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(GroceryItem groceryItem)
        {
            if (ModelState.IsValid == true)
            {
                return RedirectToAction("Index");
            }

            return View(groceryItem);
        }
    }
}
