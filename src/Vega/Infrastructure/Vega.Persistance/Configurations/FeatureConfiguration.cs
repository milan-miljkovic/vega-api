using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Vega.Domain;

namespace Vega.Persistance.Configurations
{
    public class FeatureConfiguration : BaseEntityConfiguration<Feature>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Feature> builder)
        {
            builder.HasIndex(m => m.Name).IsUnique(true);
            builder.Property(f => f.Name).HasMaxLength(255).IsRequired();
        }
    }
}
