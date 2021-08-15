using Domain;
using Domain.Moisture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class SeedHelper
    {
        public static async Task SeedData(DataContext context)

        {
            if (!context.MoistureContents.Any())
            {
                var project1 = new Project()
                {
                    Id = Guid.NewGuid(),
                    Name = "Adelaide Agriculture",
                    Code = "AAA123",
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15),
                };
                var project2 = new Project()
                {
                    Id = Guid.NewGuid(),
                    Name = "Brisbane Agriculture",
                    Code = "BBA456",
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15),
                };

                var project3 = new Project()
                {
                    Id = Guid.NewGuid(),
                    Name = "Sydney Agriculture",
                    Code = "SDA426",
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15),
                };

                var project4 = new Project()
                {
                    Id = Guid.NewGuid(),
                    Name = "Hobart Agriculture",
                    Code = "HOA426",
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15),
                };

                var balanceEquipment1 = new BalanceEquipment()
                {
                    Id = Guid.NewGuid(),
                    Name = "Balance 1",
                    Code = "01BAL",
                    ManufactureDate = new DateTime(2021, 08, 15),
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15),

                };

                var balanceEquipment2 = new BalanceEquipment()
                {
                    Id = Guid.NewGuid(),
                    Name = "Balance 2",
                    Code = "02BAL",
                    ManufactureDate = new DateTime(2021, 08, 15),
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15),

                };

                var ovenEquipment1 = new OvenEquipment()
                {
                    Id = Guid.NewGuid(),
                    Name = "Oven 1",
                    Code = "01OVN",
                    ManufactureDate = new DateTime(2021, 08, 15),
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15),
                };

                var ovenEquipment2 = new OvenEquipment()
                {
                    Id = Guid.NewGuid(),
                    Name = "Oven 2",
                    Code = "02OVN",
                    ManufactureDate = new DateTime(2021, 08, 15),
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15),
                };

                var specification1 = new Specification()
                {
                    Id = Guid.NewGuid(),
                    Name = "Specification 01",
                    Code = "01Spec",
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15),
                };

                var specification2 = new Specification()
                {
                    Id = Guid.NewGuid(),
                    Name = "Specification 02",
                    Code = "02Spec",
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15),
                };


                var sourceMaterial1 = new SourceMaterial()
                {
                    Id = Guid.NewGuid(),
                    SourceName = "Source 01",
                    MaterialDesciption = "Soil and Rock 1",
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15)
                };

                var sourceMaterial2 = new SourceMaterial()
                {
                    Id = Guid.NewGuid(),
                    SourceName = "Source 01",
                    MaterialDesciption = "Soil and Rock 2",
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15)
                };

                var sample1 = new Sample()
                {
                    Id = Guid.NewGuid(),
                    Name = "Barossa Soil ",
                    SampledBy = "Jack Phan",
                    SampledDate = new DateTime(2021, 08, 15),
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15),
                    Project = project1
                };

                var sample2 = new Sample()
                {
                    Id = Guid.NewGuid(),
                    Name = "Farm Soil ",
                    SampledBy = "Emily Phan",
                    SampledDate = new DateTime(2021, 08, 15),
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15),
                    Project = project2
                };


                var preparation1 = new Preparation()
                {
                    Id = Guid.NewGuid(),
                    Method = "B",
                    DryingTemperature = 100,
                    Balance = balanceEquipment1,
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15),
                    MaterialExcluded = "Rock",
                    VisualNomialPraticalSize = 75,
                };

                var preparation2 = new Preparation()
                {
                    Id = Guid.NewGuid(),
                    Method = "A",
                    DryingTemperature = 90,
                    Balance = balanceEquipment2,
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15)
                };

                var standardTestMethod1 = new StandardTestMethod()
                {
                    Id = Guid.NewGuid(),
                    Name = "Water (Moisture) Content of Soil and Rock by Mass",
                    Code = "ASTM D2216 - 2017",
                    Description = "Standard Test Methods for Laboratory Determination of Water (Moisture) Content of Soil and Rock by Mass",
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15)
                };

                var moistureContent1 = new MoistureContent()
                {
                    Id = Guid.NewGuid(),
                    Project = project1,
                    SourceMaterial = sourceMaterial1,
                    Specification = specification1,
                    Sample = sample1,
                    Preparation = preparation1,
                    StandardTestMethod = standardTestMethod1,
                    WorksheetId = "EST-W000001-S1",
                    TareId = "MT001",
                    TareMass = 300.0,
                    TareAndMaterialWetMass = 2859.6,
                    TareAndMaterialDryMass = 2525.7,
                    MaterialDryMass = 2225.7,
                    WaterContentPercentage = 15,
                    TesterName = "Julia Phan",
                    CheckerName = "Andrew Phan",
                    SelectMaterialExcluded = true,
                    DateTested = new DateTime(2021, 08, 15),
                    DateChecked = new DateTime(2021, 08, 15),
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15)
                };


                var moistureContent2 = new MoistureContent()
                {
                    Id = Guid.NewGuid(),
                    Project = project2,
                    SourceMaterial = sourceMaterial2,
                    Specification = specification2,
                    Sample = sample2,
                    Preparation = preparation2,
                    StandardTestMethod = standardTestMethod1,
                    WorksheetId = "EST-W000002-S2",
                    TareId = "MT002",
                    TareMass = 300.0,
                    TareAndMaterialWetMass = 4000.0,
                    TareAndMaterialDryMass = 3260.0,
                    MaterialDryMass = 2960,
                    WaterContentPercentage = 25,
                    TesterName = "David Phan",
                    CheckerName = "Quoc Phan",
                    DateTested = new DateTime(2021, 08, 15),
                    DateChecked = new DateTime(2021, 08, 15),
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15)
                };

                var moistureContent3 = new MoistureContent()
                {
                    Id = Guid.NewGuid(),
                    Project = project3,
                    SourceMaterial = sourceMaterial2,
                    Specification = specification2,
                    Sample = sample2,
                    Preparation = preparation2,
                    StandardTestMethod = standardTestMethod1,
                    WorksheetId = "EST-W000003-S3",
                    TareId = "MT003",
                    TareMass = 300.0,
                    TareAndMaterialWetMass = 2859.6,
                    TareAndMaterialDryMass = 2525.7,
                    MaterialDryMass = 2225.7,
                    WaterContentPercentage = 15.0,
                    TesterName = "Lee Phan",
                    CheckerName = "Noea Phan",
                    DateTested = new DateTime(2021, 08, 15),
                    DateChecked = new DateTime(2021, 08, 15),
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15)
                };

                var moistureContent4 = new MoistureContent()
                {
                    Id = Guid.NewGuid(),
                    Project = project4,
                    SourceMaterial = sourceMaterial2,
                    Specification = specification2,
                    Sample = sample2,
                    Preparation = preparation2,
                    StandardTestMethod = standardTestMethod1,
                    WorksheetId = "EST-W000004-S4",
                    TareId = "MT004",
                    TareMass = 300.0,
                    TareAndMaterialWetMass = 4000.0,
                    TareAndMaterialDryMass = 3200.0,
                    MaterialDryMass = 2900,
                    WaterContentPercentage = 27.6,
                    TesterName = "Olivia Phan",
                    CheckerName = "Willow Phan",
                    DateTested = new DateTime(2021, 08, 15),
                    DateChecked = new DateTime(2021, 08, 15),
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15)
                };

                await context.MoistureContents.AddRangeAsync(moistureContent1, moistureContent2, moistureContent3, moistureContent4);
                await context.SaveChangesAsync();
            }
        }
    }
}
