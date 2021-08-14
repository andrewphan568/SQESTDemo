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

        public DbSet<MoistureContent> MoistureContents { get; set; }
     

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (builder is null) throw new ArgumentNullException(nameof(builder));
            base.OnModelCreating(builder);

            #region Seed Data
            //Should create another class to store Seed Data
            var project = new Project()
            {
                Id = new Guid("8606b885-bde6-4572-8c75-9e714858cf67"),
                Name = "Adelaide Agriculture",
                Code = "AAA123",
                CreatedAtUtc = DateTime.MinValue,
                UpdatedAtUtc = DateTime.MinValue,
            };                   

            var balanceEquipment = new BalanceEquipment() {
                Id = new Guid("a50bf529-1712-44a8-b12d-d86e336fcf0c"),
                Name = "Balance",
                Code = "01BAL",
                ManufactureDate = DateTime.MinValue,
                CreatedAtUtc = DateTime.MinValue,
                UpdatedAtUtc = DateTime.MinValue,

            };

            var ovenEquipment = new OvenEquipment()
            {
                Id = new Guid("226b5d9f-3e75-4b6a-9d46-62725d947f90"),
                Name = "Oven",
                Code = "01Ove",
                ManufactureDate = DateTime.MinValue,
                CreatedAtUtc = DateTime.MinValue,
                UpdatedAtUtc = DateTime.MinValue,
            };

            var specification = new Specification() {
                Id = new Guid("03e9993b-b782-4e84-81a9-f9489cb4a689"),
                Name = "Specification01",
                Code = "01Spec",              
                CreatedAtUtc = DateTime.MinValue,
                UpdatedAtUtc = DateTime.MinValue,
            };


            var sourceMaterial = new SourceMaterial() {
                Id = new Guid("29d35a08-3e09-4108-bef4-419b007dcb38"),
                SourceName = "Source01",
                MaterialDesciption ="Soil and Rock",
                CreatedAtUtc = DateTime.MinValue,
                UpdatedAtUtc = DateTime.MinValue,
            };

            var sample = new Sample()
            {
                Id = new Guid("45d8f01c-5bca-4267-8d68-5f8f983fedc6"),
                Name = "Barossa Soil ",
                SampledBy = "Andrew Phan",
                SampledDate = DateTime.MinValue,
                CreatedAtUtc = DateTime.MinValue,
                UpdatedAtUtc = DateTime.MinValue,             
                ProjectId = project.Id
            };


            var preparation = new Preparation()
            {
                Id = new Guid("2b1e6481-0c73-434e-8756-061e20e16d70"),
                Method = "B",
                DryingTemperature = 100,
                BalanceId = balanceEquipment.Id,       
                CreatedAtUtc = DateTime.MinValue,
                UpdatedAtUtc = DateTime.MinValue,
            };           

            var moistureContent = new MoistureContent() {
                Id = new Guid("6d865d8d-d05a-43b1-a739-0cec7a3a1fc1"),             
                ProjectId=project.Id,
                SourceMaterialId = sourceMaterial.Id,
                SpecificationId =specification.Id,
                SampleId = sample.Id,               
                PreparationId = preparation.Id,           
                TareId= "MT001",
                TareMass=300.0,
                TareAndMaterialWetMass =2859.6,            
                TareAndMaterialDryMass = 2525.7,
                MaterialDryMass = 2225.7,
                WaterContentPercentage = 15,
                TesterName = "Andrew Phan",
                CheckerName = "Andrew Phan",
                DateTested = DateTime.MinValue,
                DateChecked = DateTime.MinValue,
                CreatedAtUtc = DateTime.MinValue,
                UpdatedAtUtc = DateTime.MinValue,
            };
            

            #endregion

            builder.Entity<Project>(entity =>
            {
                entity.HasData(project);
            });                     

            builder.Entity<BalanceEquipment>(entity =>
            {
                entity.HasData(balanceEquipment);
            });

            builder.Entity<OvenEquipment>(entity =>
            {
                entity.HasData(ovenEquipment);
            });

            builder.Entity<Specification>(entity =>
            {
                entity.HasData(specification);
            });

            builder.Entity<SourceMaterial>(entity =>
            {
                entity.HasData(sourceMaterial);
            });

            builder.Entity<Sample>(entity =>
            {
                entity.HasData(sample);
            });
            builder.Entity<Preparation>(entity =>
            {
                entity.HasData(preparation);
            });

            builder.Entity<MoistureContent>(entity =>
            {                   
                entity.HasData(moistureContent);
            });            
        }
    }
}
