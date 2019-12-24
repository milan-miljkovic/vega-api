using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Vega.Domain;

namespace Vega.Persistance.Configurations
{
    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.LastModified).ValueGeneratedOnAddOrUpdate();
        }

        /// <summary>
        /// Configure model entity
        /// </summary>
        /// <param name="builder"></param>
        public abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
    }
}
