using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tumultu.Domain.Entities;

namespace Tumultu.Infrastructure.Database.EFCore.Configuration;

internal class AnalysisResultEntityTypeConfiguration : IEntityTypeConfiguration<AnalysisResult>
{
    public void Configure(EntityTypeBuilder<AnalysisResult> builder)
    {
        
        //TODO add property constraints and indexes (ex. like max length for string values)
    }
}