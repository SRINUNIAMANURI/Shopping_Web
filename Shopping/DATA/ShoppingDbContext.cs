using Microsoft.EntityFrameworkCore;
using Shopping.Models;

namespace Shopping.DATA
{
    public class ShoppingDbContext : DbContext
    {
        public ShoppingDbContext(DbContextOptions dbContext) : base(dbContext)
        {

        }

        public DbSet<Product> Products {get ;set;}
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding Customer data
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    FirstName = "Srinu",
                    LastName = "Nidamanuri",
                    Email = "srinunidamanuri@example.com",
                    PhoneNumber = "1234567890"
                }
            );
            // Seeding Address data
            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, Street = "123 Main St", City = "Jajpur", ZipCode = "755019", CustomerId = 1 }
            );
            // Seeding Product data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 1500m, Description = "High-performance laptop" },
                new Product { Id = 2, Name = "Mouse", Price = 25m, Description = "Wireless mouse" },
                new Product { Id = 3, Name = "Keyboard", Price = 50m, Description = "Mechanical keyboard" }
            );
            // Seeding Order data
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, OrderDate = DateTime.Today, CustomerId = 1, Amount = 1550m }
            );
            // Seeding OrderItem data
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { Id = 1, ProductId = 1, Quantity = 1, ProductPrice= 1500m, OrderId = 1 },
                new OrderItem { Id = 2, ProductId = 2, Quantity = 2, ProductPrice= 25m, OrderId = 1 }
            );
        }
    }
}
