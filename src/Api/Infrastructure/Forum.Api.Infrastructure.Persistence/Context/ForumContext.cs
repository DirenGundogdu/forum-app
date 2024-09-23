using System;
using System.Reflection;
using Forum.Api.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Forum.Api.Infrastructure.Persistence.Context;

public class ForumContext : DbContext
{

    public const string DEFAULT_SCHEMA = "dbo";

    public ForumContext(DbContextOptions<ForumContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Entry> Entries { get; set; }

    public DbSet<EntryVote> EntryVotes { get; set; }
    public DbSet<EntryComment> EntryComments { get; set; }
    public DbSet<EntryFavorite> EntryFavorites { get; set; }
    public DbSet<EntryCommentFavorite> EntryCommentFavorites { get; set; }
    public DbSet<EntryCommentVote> EntryCommentVotes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override int SaveChanges()
    {
        OnBeforeSave();
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        OnBeforeSave();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        OnBeforeSave();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        OnBeforeSave();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void OnBeforeSave() 
    {
        var addedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Added).Select(x => (BaseEntity)x.Entity);
        PrepareAddedEntities(addedEntities);
    }

    private void PrepareAddedEntities(IEnumerable<BaseEntity> entities)
    {
        foreach (var entity in entities)
        {
            if(entity.CreateDate == DateTime.MinValue){
            entity.CreateDate = DateTime.Now;
            }
        }
    }


}
