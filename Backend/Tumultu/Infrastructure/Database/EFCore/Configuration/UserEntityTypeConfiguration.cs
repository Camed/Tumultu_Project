using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tumultu.Domain.Entities;

namespace Tumultu.Infrastructure.Database.EFCore.Configuration;

internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.OwnsMany(entity => entity.Notes);
        
        //TODO add property constraints and indexes (ex. like max length for string values)
    }
}