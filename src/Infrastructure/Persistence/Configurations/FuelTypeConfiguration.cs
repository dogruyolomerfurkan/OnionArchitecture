using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Configurations.Common;

namespace Persistence.Configurations;

public class FuelTypeConfiguration : BaseConfiguration<FuelType>
{
    public override void Configure(EntityTypeBuilder<FuelType> builder)
    {
        base.Configure(builder);
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
    }
}
