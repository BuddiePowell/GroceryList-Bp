using Microsoft.AspNetCore.Mvc;
using Powell_GroceryList.Models;

namespace Powell_GroceryList.Controllers
{
    public class GroceriesController : Controller
    {
        public IActionResult Index()
        {
            GroceryItem bananas = new GroceryItem();
            bananas.Name = "Bananas";
            bananas.Store = "Piggy Wiggly";
            return View(bananas);
        }
    }
}
