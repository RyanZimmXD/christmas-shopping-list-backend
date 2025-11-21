using Microsoft.EntityFrameworkCore;

namespace shopping_list_backend.Models
{
    public class ShoppingListDBContext:DbContext
    {
        public ShoppingListDBContext(DbContextOptions<ShoppingListDBContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.ShoppingItems)
                .WithOne()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }



        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingItem> ShoppingItems { get; set; }
    }
}
