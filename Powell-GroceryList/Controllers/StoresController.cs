using Microsoft.AspNetCore.Mvc;
using Powell_GroceryList.Models;
using Powell_GroceryList.Services;

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
            List<Store> storeList = _databaseContext.GetAllStores();

            return View(storeList);
        }
    }
}
