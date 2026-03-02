using Powell_GroceryList.Models;
using Microsoft.AspNetCore.Mvc;

namespace Powell_GroceryList.Controllers
{
    public class StoresController : Controller
    {
        public IActionResult Index()
        {
            Store pigglyWiggly = new Store();
            pigglyWiggly.Name = "Piggly Wiggly";
            pigglyWiggly.Address = "202 Street Address";
            pigglyWiggly.City = "Madison";
            pigglyWiggly.State = "WI";
            pigglyWiggly.PhoneNumber = "608-303-2983";

            List<Store> storeList = new List<Store>();
            storeList.Add(pigglyWiggly);
            return View(storeList);
        }
    }
}
