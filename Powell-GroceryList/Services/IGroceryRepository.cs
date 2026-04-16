using MySql.Data.MySqlClient;
using Powell_GroceryList.Models;

namespace Powell_GroceryList.Services
{
    public interface IGroceryRepository
    {
        void AddGroceryItem(GroceryItem groceryItem);
        void AddStore(Store store);
        List<GroceryItem> GetAllGroceryItems();
        List<Store> GetAllStores();
        
    }
}