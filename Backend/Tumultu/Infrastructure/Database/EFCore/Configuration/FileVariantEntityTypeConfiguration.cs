using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tumultu.Domain.Entities;

namespace Tumultu.Infrastructure.Database.EFCore.Configuration;

internal class FileVariantEntityTypeConfiguration : IEntityTypeConfiguration<FileVariant>
{
    public void Configure(EntityTypeBuilder<FileVariant> builder)
    {
        builder.OwnsMany(entity => entity.Tags);

        builder.OwnsOne(entity => entity.Metadata);

        //TODO add property constraints and indexes (ex. like max length for string values)
    }
}