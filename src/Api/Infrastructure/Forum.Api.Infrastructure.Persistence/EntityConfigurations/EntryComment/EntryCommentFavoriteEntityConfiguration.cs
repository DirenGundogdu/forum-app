using System;
using Forum.Api.Core.Domain.Models;
using Forum.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Api.Infrastructure.Persistence.EntityConfigurations.EntryComment;

public class EntryCommentFavoriteEntityConfiguration : BaseEntityConfiguration<Forum.Api.Core.Domain.Models.EntryCommentFavorite>
{
    public override void Configure(EntityTypeBuilder<EntryCommentFavorite> builder)
    {
        base.Configure(builder);

        builder.ToTable("entrycommentfavorite", ForumContext.DEFAULT_SCHEMA);

        builder.HasOne(x => x.EntryComment).WithMany(x => x.EntryCommentFavorites).HasForeignKey(x => x.EntryCommentId);

        builder.HasOne(x => x.CreatedUser).WithMany(x => x.EntryCommentFavorites).HasForeignKey(x => x.CreatedById).OnDelete(DeleteBehavior.Restrict);;
    }


}
