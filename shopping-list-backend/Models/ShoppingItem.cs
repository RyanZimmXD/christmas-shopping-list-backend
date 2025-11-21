using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopping_list_backend.Models
{
    public class ShoppingItem
    {
        [Key]
        public string Id { get; set; }
        
        public string UserId { get; set; }
        public string Item { get; set; }
        
        public bool Purchased { get; set; } = false;

    }
}
