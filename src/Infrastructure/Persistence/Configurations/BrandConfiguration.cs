using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Configurations.Common;

namespace Persistence.Configurations;

public class BrandConfiguration : BaseConfiguration<Brand>
{
    public override void Configure(EntityTypeBuilder<Brand> builder)
    {
        base.Configure(builder);
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

        builder.HasData(new Brand { Id = 1, Name = "Toyota", IsDeleted = false });
    }
}
