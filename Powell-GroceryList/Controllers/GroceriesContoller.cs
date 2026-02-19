using Microsoft.AspNetCore.Mvc;
using Powell_GroceryList.Models;

namespace Powell_GroceryList.Controllers
{
    public class GroceriesController : Controller
    {
        public IActionResult Index()

        {
            List<GroceryItem> groceryItems = new List<GroceryItem>();
            GroceryItem bananas = new GroceryItem();
            bananas.Name = "Bananas";
            bananas.Store = "Piggy Wiggly";

            GroceryItem milk = new GroceryItem();
            milk.Name = "Milk";
            bananas.Store = "Piggy Wiggly";

            GroceryItem avocadoes = new GroceryItem();
            avocadoes.Name = "Avocadoes";
            avocadoes.Store = "Costco";

            groceryItems.Add(bananas);
            groceryItems.Add(milk);
            groceryItems.Add(avocadoes);

            return View(groceryItems);
        }
    }
}
