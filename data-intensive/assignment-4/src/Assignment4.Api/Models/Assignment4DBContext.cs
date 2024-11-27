using Microsoft.EntityFrameworkCore;
using Assignment4.Api.Entities;

namespace Assignment4.Api.Models;

public class Assignment4DBContext : DbContext
{
    public Assignment4DBContext(DbContextOptions<Assignment4DBContext> options) : base(options)
    {   
    }

    public DbSet<FamilySql> FamiliesSql { get; set; } 

    public DbSet<ParentSql> ParentsSql { get; set; }

    public DbSet<ChildSql> ChildrenSql { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<FamilySql>()
        //    .HasMany(f => f.Parents)
        //    .WithOne(p => p.Family)
        //    .HasForeignKey(p => p.FamilyId)
        //    .OnDelete(DeleteBehavior.Cascade); // Enable cascade delete for Parents

        //modelBuilder.Entity<FamilySql>()
        //    .HasMany(f => f.Children)
        //    .WithOne(c => c.Family)
        //    .HasForeignKey(c => c.FamilyId)
        //    .OnDelete(DeleteBehavior.Cascade); // Enable cascade delete for Children
    }
}
