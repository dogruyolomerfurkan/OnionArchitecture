using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Configurations.Common;

namespace Persistence.Configurations;

public class VehicleCategoryConfiguration : BaseConfiguration<VehicleCategory>
{
    public override void Configure(EntityTypeBuilder<VehicleCategory> builder)
    {
        base.Configure(builder);
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
    }
}
