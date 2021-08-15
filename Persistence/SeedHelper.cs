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
                    Id = new Guid("8606b885-bde6-4572-8c75-9e714858cf67"),
                    Name = "Adelaide Agriculture",
                    Code = "AAA123",
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15),
                };
                var project2 = new Project()
                {
                    Id = new Guid("7c71d143-1cd8-4bc0-a963-3fefb9062392"),
                    Name = "Brisbane Agriculture",
                    Code = "BBA456",
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15),
                };

                var project3 = new Project()
                {
                    Id = new Guid("bc12fad7-c35a-45fb-8eac-4d2c8bbfc0bf"),
                    Name = "Sydney Agriculture",
                    Code = "SDA426",
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15),
                };

                var project4 = new Project()
                {
                    Id = new Guid("d1b4356a-b347-439b-ac6b-84c106f1cd3b"),
                    Name = "Hobart Agriculture",
                    Code = "HOA426",
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15),
                };

                var balanceEquipment1 = new BalanceEquipment()
                {
                    Id = new Guid("cafedcbd-be90-45d7-923e-ce1b2a1563a5"),
                    Name = "Balance 1",
                    Code = "01BAL",
                    ManufactureDate = new DateTime(2021, 08, 15),
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15),

                };

                var balanceEquipment2 = new BalanceEquipment()
                {
                    Id = new Guid("0ce08113-7675-428e-be1f-d07de73c3b2d"),
                    Name = "Balance 2",
                    Code = "02BAL",
                    ManufactureDate = new DateTime(2021, 08, 15),
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15),

                };

                var ovenEquipment1 = new OvenEquipment()
                {
                    Id = new Guid("226b5d9f-3e75-4b6a-9d46-62725d947f90"),
                    Name = "Oven 1",
                    Code = "01OVN",
                    ManufactureDate = new DateTime(2021, 08, 15),
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15),
                };

                var ovenEquipment2 = new OvenEquipment()
                {
                    Id = new Guid("c0568854-58c4-4943-84a3-8bd4b82744ee"),
                    Name = "Oven 2",
                    Code = "02OVN",
                    ManufactureDate = new DateTime(2021, 08, 15),
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15),
                };

                var specification1 = new Specification()
                {
                    Id = new Guid("03e9993b-b782-4e84-81a9-f9489cb4a689"),
                    Name = "Specification 01",
                    Code = "01Spec",
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15),
                };

                var specification2 = new Specification()
                {
                    Id = new Guid("3f58fdd1-77bc-47fc-9de8-1348b313a7c8"),
                    Name = "Specification 02",
                    Code = "02Spec",
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15),
                };


                var sourceMaterial1 = new SourceMaterial()
                {
                    Id = new Guid("29d35a08-3e09-4108-bef4-419b007dcb38"),
                    SourceName = "Source 01",
                    MaterialDesciption = "Soil and Rock 1",
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15)
                };

                var sourceMaterial2 = new SourceMaterial()
                {
                    Id = new Guid("166cee7f-8419-4655-9bb0-57d177d65939"),
                    SourceName = "Source 01",
                    MaterialDesciption = "Soil and Rock 2",
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15)
                };

                var sample1 = new Sample()
                {
                    Id = new Guid("45d8f01c-5bca-4267-8d68-5f8f983fedc6"),
                    Name = "Barossa Soil ",
                    SampledBy = "Jack Phan",
                    SampledDate = new DateTime(2021, 08, 15),
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15),
                    Project = project1
                };

                var sample2 = new Sample()
                {
                    Id = new Guid("237d6d1c-dc08-4105-8e97-8d598d5aab44"),
                    Name = "Farm Soil ",
                    SampledBy = "Emily Phan",
                    SampledDate = new DateTime(2021, 08, 15),
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15),
                    Project = project2
                };


                var preparation1 = new Preparation()
                {
                    Id = new Guid("2b1e6481-0c73-434e-8756-061e20e16d70"),
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
                    Id = new Guid("9399cf01-c108-46e2-b2d1-4ffdce30aa0a"),
                    Method = "A",
                    DryingTemperature = 90,
                    Balance = balanceEquipment2,
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15)
                };

                var standardTestMethod1 = new StandardTestMethod()
                {
                    Id = new Guid("6d865d8d-d05a-43b1-a739-0cec7a3a1fc1"),
                    Name = "Water (Moisture) Content of Soil and Rock by Mass", 
                    Code = "ASTM D2216 - 2017",
                    Description = "Standard Test Methods for Laboratory Determination of Water (Moisture) Content of Soil and Rock by Mass",
                    CreatedAtUtc = new DateTime(2021, 08, 15),
                    UpdatedAtUtc = new DateTime(2021, 08, 15)
                };

                var moistureContent1 = new MoistureContent()
                {
                    Id = new Guid("6d865d8d-d05a-43b1-a739-0cec7a3a1fc1"),
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
                    Id = new Guid("744eb79c-50c9-4387-b020-bf3908ebc8e8"),
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
                    Id = new Guid("f2dc87ee-8e79-4ee1-a9a2-388af9b589e2"),
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
                    Id = new Guid("b5791249-9fd0-4f6f-b17a-69778e9d656f"),
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

                await context.MoistureContents.AddRangeAsync(moistureContent1, moistureContent2,moistureContent3, moistureContent4);
                await context.SaveChangesAsync();
            }
        }
    }
}
