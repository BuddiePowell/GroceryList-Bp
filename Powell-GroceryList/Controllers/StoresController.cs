using Microsoft.AspNetCore.Mvc;

namespace Powell_GroceryList.Controllers
{
    public class StoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
