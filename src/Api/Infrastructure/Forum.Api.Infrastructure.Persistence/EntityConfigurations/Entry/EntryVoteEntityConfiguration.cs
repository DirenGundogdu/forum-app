using System;
using Forum.Api.Core.Domain.Models;
using Forum.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Api.Infrastructure.Persistence.EntityConfigurations.Entry;

public class EntryVoteEntityConfiguration : BaseEntityConfiguration<Forum.Api.Core.Domain.Models.EntryVote>
{
    public override void Configure(EntityTypeBuilder<Forum.Api.Core.Domain.Models.EntryVote> builder)
    {
        base.Configure(builder);

        builder.ToTable("entryvote", ForumContext.DEFAULT_SCHEMA);

        builder.HasOne(x => x.Entry).WithMany(x => x.EntryVotes).HasForeignKey(x => x.EntryId);
    }

}
