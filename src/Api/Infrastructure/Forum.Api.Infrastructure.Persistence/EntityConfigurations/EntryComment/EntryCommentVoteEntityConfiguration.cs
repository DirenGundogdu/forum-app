using System;
using Forum.Api.Core.Domain.Models;
using Forum.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Api.Infrastructure.Persistence.EntityConfigurations.EntryComment;

public class EntryCommentVoteEntityConfiguration : BaseEntityConfiguration<Forum.Api.Core.Domain.Models.EntryCommentVote>
{
    public override void Configure(EntityTypeBuilder<EntryCommentVote> builder)
    {
        base.Configure(builder);

        builder.ToTable("entrycommentvote", ForumContext.DEFAULT_SCHEMA);

        builder.HasOne(x => x.EntryComment).WithMany(x => x.EntryCommentVotes).HasForeignKey(x => x.EntryCommentId);
    }

}
