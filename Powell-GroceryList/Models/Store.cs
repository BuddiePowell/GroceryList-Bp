using System.ComponentModel.DataAnnotations;
using System.Xml.Schema;

namespace Powell_GroceryList.Models
{
    public class Store
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
