using System.Data.Entity;

namespace ProductCart.Models.Models
{
    public class StoreEntities : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategorys{ get; set; }
        public DbSet<Manufacture> Manufactures { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}