using Microsoft.AspNetCore.Mvc;

namespace Powell_GroceryList.Controllers
{
    public class GroceriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
