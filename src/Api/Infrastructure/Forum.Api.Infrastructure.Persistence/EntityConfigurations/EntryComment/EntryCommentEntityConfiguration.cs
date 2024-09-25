using System;
using Forum.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Api.Infrastructure.Persistence.EntityConfigurations.EntryComment;

public class EntryCommentEntityConfiguration : BaseEntityConfiguration<Forum.Api.Core.Domain.Models.EntryComment>
{
    public override void Configure(EntityTypeBuilder<Core.Domain.Models.EntryComment> builder)
    {
        base.Configure(builder);

        builder.ToTable("entrycomment", ForumContext.DEFAULT_SCHEMA);

        builder.HasOne(x => x.CreatedBy).WithMany(x => x.EntryComments).HasForeignKey(x => x.CreatedById).OnDelete(DeleteBehavior.Restrict);;

        builder.HasOne(x => x.Entry).WithMany(x => x.EntryComments).HasForeignKey(x => x.EntryId);
    }

}
