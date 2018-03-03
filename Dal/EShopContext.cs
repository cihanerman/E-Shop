using E_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Dal {
    public class EShopContext : DbContext {
        public EShopContext (DbContextOptions<EShopContext> options) : base (options) { }
        public EShopContext() { }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }
    }
}