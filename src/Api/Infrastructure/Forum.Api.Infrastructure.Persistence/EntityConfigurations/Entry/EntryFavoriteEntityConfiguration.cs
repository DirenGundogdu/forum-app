using System;
using Forum.Api.Core.Domain.Models;
using Forum.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Api.Infrastructure.Persistence.EntityConfigurations.Entry;

public class EntryFavoriteEntityConfiguration : BaseEntityConfiguration<Forum.Api.Core.Domain.Models.EntryFavorite>
{
    public override void Configure(EntityTypeBuilder<EntryFavorite> builder)
    {
        base.Configure(builder);

        builder.ToTable("entryfavorite", ForumContext.DEFAULT_SCHEMA);

        builder.HasOne(x => x.Entry).WithMany(x => x.EntryFavorites).HasForeignKey(x => x.EntryId);

        builder.HasOne(x => x.CreatedUser).WithMany(x => x.EntryFavorites).HasForeignKey(x => x.CreatedById).OnDelete(DeleteBehavior.Restrict);
    }

}
