using GlobalShopping.Interfaces;
using GlobalShopping.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace GlobalShopping.Data
{
    public class JapanShoppingContext : DbContext, IDbcontext
    {
        public JapanShoppingContext(DbContextOptions<JapanShoppingContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Product>().Property(m => m.ID).HasColumnType("varchar").HasConversion(
        //v => v.ToString(),
        //v => ObjectId.Parse(v));
        //    modelBuilder.Entity<Person>().Ignore(m => m.MID);
        //    modelBuilder.Entity<OrderLine>().Ignore(m => m.MID).Ignore(n => n.MOrder).Ignore(n => n.MOrderID).Property(m => m.ProductID).HasColumnType("varchar").HasConversion(
        //v => v.ToString(),
        //v => ObjectId.Parse(v));
        //    modelBuilder.Entity<Order>().Ignore(m => m.MID).Ignore(n => n.MPersonID).Ignore(n => n.MPerson);
        //    modelBuilder.Entity<ProductImage>().Property(m => m.ProductID).HasColumnType("varchar").HasConversion(
        //v => v.ToString(),
        //v => ObjectId.Parse(v));
        ////    modelBuilder.Entity<ProductImage>().Property(m => m.ID).HasColumnType("varchar").HasConversion(
        ////v => v.ToString(),
        ////v => ObjectId.Parse(v));
        //    modelBuilder.Entity<ProductReview>().Ignore(m => m.MID).Ignore(n => n.MProductID);
        }

        public DbSet<GlobalShopping.Models.UserAccount> UserAccount { get; set; } = default!;
        public DbSet<GlobalShopping.Models.Product> Product { get; set; } = default!;
        public DbSet<GlobalShopping.Models.Order> Order { get; set; } = default!;
        public DbSet<GlobalShopping.Models.OrderLine> OrderLine { get; set; } = default!;
        public DbSet<GlobalShopping.Models.ProductReview> ProductReview { get; set; } = default!;
        public DbSet<GlobalShopping.Models.ProductImage> ProductImage { get; set; } = default!;
        public DbSet<GlobalShopping.Models.WarehouseStock> WarehouseStock { get; set; } = default!;
    }
}
