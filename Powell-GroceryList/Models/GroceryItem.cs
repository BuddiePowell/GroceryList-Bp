using System.ComponentModel.DataAnnotations;

namespace Powell_GroceryList.Models
{
    public class GroceryItem
    {
        public int Id { get; set; }

        [Required]
       public string Name { get; set; }

        public Store? Store {  get; set; }


        [Required]
        public int StoreId { get; set; }
    }
}
