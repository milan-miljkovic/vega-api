using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Vega.Domain;

namespace Vega.Persistance.Configurations
{
    public class ModelConfiguration : BaseEntityConfiguration<Model>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Model> builder)
        {
            builder.Property(m => m.Name).HasMaxLength(255);
        }
    }
}
