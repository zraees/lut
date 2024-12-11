using GlobalShopping.Interfaces;
using GlobalShopping.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using System.Configuration;

namespace GlobalShopping.Data
{
    public class MongoDBContext : DbContext, IDbcontext
    {
        public MongoDBContext(DbContextOptions<MongoDBContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<ProductReview>().ToCollection("ProductReview");
            //modelBuilder.Entity<ProductImage>().ToCollection("ProductImage").Property(m => m.ID).ValueGeneratedOnAdd();
            //modelBuilder.Entity<Product>().ToCollection("Product").Ignore(m => m.ID).Property(m => m.MID).ValueGeneratedOnAdd();
            //modelBuilder.Entity<Person>().ToCollection("Person").Ignore(m => m.ID).Property(m => m.MID).ValueGeneratedOnAdd();
            modelBuilder.Entity<UserAccount>().ToCollection("Customer");
            modelBuilder.Entity<Product>().ToCollection("Item");
            //modelBuilder.Entity<Order>().Ignore(m => m.Person).ToCollection("Order");
            //modelBuilder.Entity<OrderLine>().Ignore(m => m.Order).Ignore(m => m.Product).ToCollection("OrderLine");
            modelBuilder.Entity<ProductImage>().ToCollection("ProductImage");
            modelBuilder.Entity<ProductReview>().ToCollection("ProductReview");
            modelBuilder.Entity<Order>().Ignore(m => m.User);
            //modelBuilder.Entity<Order>().Ignore(m => m.Person);
        }

        public DbSet<GlobalShopping.Models.Product> Product { get; set; } = default!;
        public DbSet<GlobalShopping.Models.UserAccount> UserAccount { get; set; } = default!;
        public DbSet<GlobalShopping.Models.Order> Order { get; set; } = default!;
        public DbSet<GlobalShopping.Models.OrderLine> OrderLine { get; set; } = default!;
        public DbSet<GlobalShopping.Models.ProductReview> ProductReview { get; set; } = default!;
        public DbSet<GlobalShopping.Models.ProductImage> ProductImage { get; set; } = default!;
        public DbSet<GlobalShopping.Models.WarehouseStock> WarehouseStock { get; set; } = default!;
    }
}
