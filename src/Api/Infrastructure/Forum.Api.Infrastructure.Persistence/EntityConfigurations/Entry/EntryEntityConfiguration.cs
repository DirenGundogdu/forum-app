using System;
using Forum.Api.Core.Domain.Models;
using Forum.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Api.Infrastructure.Persistence.EntityConfigurations.Entry;

public class EntryEntityConfiguration : BaseEntityConfiguration<Forum.Api.Core.Domain.Models.Entry>
{
    public override void Configure(EntityTypeBuilder<Forum.Api.Core.Domain.Models.Entry> builder)
    {
        base.Configure(builder);

        builder.ToTable("entry", ForumContext.DEFAULT_SCHEMA);

        builder.HasOne(x => x.CreatedBy).WithMany(x => x.Entries).HasForeignKey(x => x.CreatedById);

    }
    
}
