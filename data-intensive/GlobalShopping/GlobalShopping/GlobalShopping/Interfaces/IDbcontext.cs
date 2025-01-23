using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GlobalShopping.Interfaces
{
    public interface IDbcontext
    {
        DbSet<GlobalShopping.Models.UserAccount> UserAccount { get; set; }
        DbSet<GlobalShopping.Models.Product> Product { get; set; }
        DbSet<GlobalShopping.Models.Order> Order { get; set; }
        DbSet<GlobalShopping.Models.OrderLine> OrderLine { get; set; }
        DbSet<GlobalShopping.Models.ProductReview> ProductReview { get; set; }
        DbSet<GlobalShopping.Models.ProductImage> ProductImage { get; set; }
        DbSet<GlobalShopping.Models.WarehouseStock> WarehouseStock { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        EntityEntry Attach(object entity);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry Entry(object entity);
    }
}
