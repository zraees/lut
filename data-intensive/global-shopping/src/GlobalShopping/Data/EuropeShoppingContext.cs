using GlobalShopping.Interfaces;
using GlobalShopping.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace GlobalShopping.Data
{
    public class EuropeShoppingContext : DbContext, IDbcontext
    {
        public EuropeShoppingContext(DbContextOptions<EuropeShoppingContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().Property(m => m.ID).HasColumnType("varchar").HasConversion(
        v => v.ToString(),
        v => ObjectId.Parse(v));
            modelBuilder.Entity<UserAccount>().Property(m => m.ID).HasColumnType("varchar").HasConversion(
        v => v.ToString(),
        v => ObjectId.Parse(v));
            modelBuilder.Entity<OrderLine>().Property(m => m.ID).HasColumnType("varchar").HasConversion(
        v => v.ToString(),
        v => ObjectId.Parse(v));
            modelBuilder.Entity<OrderLine>().Property(m => m.ProductID).HasColumnType("varchar").HasConversion(
        v => v.ToString(),
        v => ObjectId.Parse(v));
            modelBuilder.Entity<Order>().Property(m => m.ID).HasColumnType("varchar").HasConversion(
        v => v.ToString(),
        v => ObjectId.Parse(v));
            modelBuilder.Entity<Order>().Property(m => m.UserID).HasColumnType("varchar").HasConversion(
        v => v.ToString(),
        v => ObjectId.Parse(v));
            modelBuilder.Entity<WarehouseStock>().Property(m => m.ID).HasColumnType("varchar").HasConversion(
        v => v.ToString(),
        v => ObjectId.Parse(v));
            modelBuilder.Entity<WarehouseStock>().Property(m => m.ProductID).HasColumnType("varchar").HasConversion(
        v => v.ToString(),
        v => ObjectId.Parse(v));
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
