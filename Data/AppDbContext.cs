using Microsoft.EntityFrameworkCore;
using ODataDemo.Models;

namespace ODataDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderLine> OrderLines => Set<OrderLine>();
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Books" },
                new Category { Id = 3, Name = "Clothing" }
            );

            // Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 1200, CategoryId = 1 },
                new Product { Id = 2, Name = "Smartphone", Price = 800, CategoryId = 1 },
                new Product { Id = 3, Name = "Novel", Price = 20, CategoryId = 2 },
                new Product { Id = 4, Name = "T-Shirt", Price = 15, CategoryId = 3 }
            );

            // Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, OrderDate = new DateTime(2025, 1, 1) },
                new Order { Id = 2, OrderDate = new DateTime(2025, 2, 10) }
            );

            // OrderLines
            modelBuilder.Entity<OrderLine>().HasData(
                new OrderLine { Id = 1, OrderId = 1, ProductId = 1, Quantity = 2 }, // 2 Laptops
                new OrderLine { Id = 2, OrderId = 1, ProductId = 3, Quantity = 5 }, // 5 Novels
                new OrderLine { Id = 3, OrderId = 2, ProductId = 2, Quantity = 1 }, // 1 Smartphone
                new OrderLine { Id = 4, OrderId = 2, ProductId = 4, Quantity = 3 }  // 3 T-Shirts
            );
        }
    }
}
