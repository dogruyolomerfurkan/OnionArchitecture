using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Configurations.Common;

namespace Persistence.Configurations
{
    public class ModelConfiguration : BaseConfiguration<Model>
    {
        public override void Configure(EntityTypeBuilder<Model> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        }
    }
}
