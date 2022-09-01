using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Configurations.Common;

namespace Persistence.Configurations;

public class GearTypeConfiguration : BaseConfiguration<GearType>
{
    public override void Configure(EntityTypeBuilder<GearType> builder)
    {
        base.Configure(builder);
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
    }
}