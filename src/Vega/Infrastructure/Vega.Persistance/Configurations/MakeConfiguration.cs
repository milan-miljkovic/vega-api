using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Vega.Domain;

namespace Vega.Persistance.Configurations
{
    class MakeConfiguration : BaseEntityConfiguration<Make>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Make> builder)
        {
            builder.HasIndex(m => m.Name).IsUnique(true);
            builder.Property(m => m.Name).HasMaxLength(255).IsRequired();
        }
    }
}
