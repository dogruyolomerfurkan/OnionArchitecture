using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Configurations.Common;

namespace Persistence.Configurations;

public class SerialConfiguration : BaseConfiguration<Serial>
{
    public override void Configure(EntityTypeBuilder<Serial> builder)
    {
        base.Configure(builder);
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

    }
}
