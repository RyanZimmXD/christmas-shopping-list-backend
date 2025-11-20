using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopping_list_backend.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Column(TypeName ="nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string PasswordHash { get; set; }

        [NotMapped]
        public List<ShoppingItem> ShoppingItems { get; set; }
    }
}
