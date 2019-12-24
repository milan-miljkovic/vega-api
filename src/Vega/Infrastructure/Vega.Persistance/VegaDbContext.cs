using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using Vega.Domain;
using Vega.Persistance.Configurations;

namespace Vega.Persistance
{
    public class VegaDbContext : DbContext
    {
        /// <summary>
        /// Constructs db context with options
        /// </summary>
        /// <param name="options"></param>
        public VegaDbContext(DbContextOptions<VegaDbContext> options) : base(options) { }

        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Feature> Features { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntityConfiguration<>).Assembly);
        }
    }
}
