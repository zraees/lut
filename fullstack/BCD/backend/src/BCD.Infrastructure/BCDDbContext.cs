// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using BCD.Domain.Entities;
using BCD.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BCD.Infrastructure;
public class BCDDbContext : DbContext
{
    public BCDDbContext(DbContextOptions<BCDDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Category> Categories { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var modifiedEntities = ChangeTracker.Entries()
                                            .Where(x => x.State == EntityState.Added
                                                    || x.State == EntityState.Modified
                                                    || x.State == EntityState.Deleted)
                                            .ToList();

        //foreach (var entity in modifiedEntities)
        //{
        //    var auditLog = new AuditLog
        //    {
        //        EntityName = entity.Entity.GetType().Name,
        //        Email = "test",
        //        Action = entity.State.ToString(),
        //        Timestamp = DateTime.UtcNow,
        //        Changes = GetModifiedChanges(entity)
        //    };

        //    AuditLogs.Add(auditLog);
        //}

        return base.SaveChangesAsync(cancellationToken);
    }

    //private string GetModifiedChanges(EntityEntry entity)
    //{
    //    var changes = new StringBuilder();

    //    foreach (var property in entity.OriginalValues.Properties)
    //    {
    //        var originalVal = entity.OriginalValues[property];
    //        var currentVal = entity.CurrentValues[property];

    //        if (Equals(originalVal, currentVal) == false)
    //        {
    //            changes.AppendLine($"{property.Name}: Original '{originalVal}' Changed to '{currentVal}'");
    //        }
    //    }

    //    return changes.ToString();
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
    }
}
