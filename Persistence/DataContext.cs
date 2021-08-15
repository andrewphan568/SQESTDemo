using Domain;
using Domain.Moisture;
using Microsoft.EntityFrameworkCore;
using System;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }      
        public DbSet<BalanceEquipment> BalanceEquipments { get; set; }
        public DbSet<OvenEquipment> OvenEquipments { get; set; }
        public DbSet<SourceMaterial> SourceMaterials { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<Sample> Samples { get; set; }
        public DbSet<Preparation> Preparations { get; set; }
        public DbSet<StandardTestMethod> StandardTestMethods { get; set; }
        public DbSet<MoistureContent> MoistureContents { get; set; }
     

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (builder is null) throw new ArgumentNullException(nameof(builder));
            base.OnModelCreating(builder);

                     
        }
    }
}
