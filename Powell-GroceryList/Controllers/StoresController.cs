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

            Store Hyvee = new Store();
            Hyvee.Name = "Hyvee";
            Hyvee.Address = "123 Street Address";
            Hyvee.City = "Milwakee";
            Hyvee.State = "WI";
            Hyvee.PhoneNumber = "609-405-1234";

            List<Store> storeList = new List<Store>();
            storeList.Add(pigglyWiggly);
            storeList.Add(Hyvee);
            return View(storeList);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Store store)
        {
            if (ModelState.IsValid == true)
            {
                return RedirectToAction("Index");
            }

            return View(store);
        }
    }
}
