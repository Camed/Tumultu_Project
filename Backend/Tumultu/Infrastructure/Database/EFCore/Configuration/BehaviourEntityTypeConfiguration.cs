using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tumultu.Domain.Entities;

namespace Tumultu.Infrastructure.Database.EFCore.Configuration;

internal class BehaviourEntityTypeConfiguration : IEntityTypeConfiguration<Behaviour>
{
    public void Configure(EntityTypeBuilder<Behaviour> builder)
    {
        //TODO add property constraints and indexes (ex. like max length for string values)
    }
}