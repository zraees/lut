using GlobalShopping.Interfaces;
using GlobalShopping.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore.Extensions;

namespace GlobalShopping.Data
{
    public class USAShoppingContext : DbContext, IDbcontext
    {
        public USAShoppingContext(DbContextOptions<USAShoppingContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<ProductImage>();
            modelBuilder.Ignore<ProductReview>();
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
