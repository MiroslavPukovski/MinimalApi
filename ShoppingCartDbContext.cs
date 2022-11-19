using Microsoft.EntityFrameworkCore;

namespace ShoppingCartList.Api
{
    public class ShoppingCartDbContext : DbContext
    {
        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options) :base(options)
        {

        }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ShoppingCart>().HasData(
                new ShoppingCart
                {
                    Id = 1,
                    isPickedUp = false,
                    ItemName = "Soap",
                    Quantity = 3
                },
                new ShoppingCart
                {
                    Id = 2,
                    isPickedUp = true,
                    ItemName = "Bread",
                    Quantity = 2
                },
                new ShoppingCart
                {
                    Id = 3,
                    isPickedUp = false,
                    ItemName = "Shampoo",
                    Quantity = 1
                }

                );
        }

    }
}