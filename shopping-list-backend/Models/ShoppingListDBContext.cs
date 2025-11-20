using Microsoft.EntityFrameworkCore;

namespace shopping_list_backend.Models
{
    public class ShoppingListDBContext:DbContext
    {
        public ShoppingListDBContext(DbContextOptions<ShoppingListDBContext> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
