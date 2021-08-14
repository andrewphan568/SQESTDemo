using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddedSomeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BalanceEquipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufactureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalanceEquipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoistureContents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SourceMaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SpecificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SampleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PreparationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TareId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TareMass = table.Column<double>(type: "float", nullable: false),
                    TareAndMaterialWetMass = table.Column<double>(type: "float", nullable: false),
                    TareAndMaterialDryMass = table.Column<double>(type: "float", nullable: false),
                    MaterialDryMass = table.Column<double>(type: "float", nullable: false),
                    WaterContentPercentage = table.Column<double>(type: "float", nullable: false),
                    SelectInsufficientSampleMass = table.Column<bool>(type: "bit", nullable: false),
                    SelectDryingTemperature = table.Column<bool>(type: "bit", nullable: false),
                    SelectMaterialExcluded = table.Column<bool>(type: "bit", nullable: false),
                    TesterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateChecked = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoistureContents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OvenEquipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufactureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OvenEquipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Preparations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DryingTemperature = table.Column<double>(type: "float", nullable: false),
                    BalanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisualNomialPraticalSize = table.Column<double>(type: "float", nullable: false),
                    MaterialExcluded = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preparations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Samples",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SampledBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SampledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SourceMaterials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SourceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialDesciption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourceMaterials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BalanceEquipments",
                columns: new[] { "Id", "Code", "CreatedAtUtc", "ManufactureDate", "Name", "UpdatedAtUtc" },
                values: new object[] { new Guid("a50bf529-1712-44a8-b12d-d86e336fcf0c"), "01BAL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Balance", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "MoistureContents",
                columns: new[] { "Id", "CheckerName", "CreatedAtUtc", "DateChecked", "DateTested", "MaterialDryMass", "PreparationId", "ProjectId", "Remarks", "SampleId", "SelectDryingTemperature", "SelectInsufficientSampleMass", "SelectMaterialExcluded", "SourceMaterialId", "SpecificationId", "TareAndMaterialDryMass", "TareAndMaterialWetMass", "TareId", "TareMass", "TesterName", "UpdatedAtUtc", "WaterContentPercentage" },
                values: new object[] { new Guid("6d865d8d-d05a-43b1-a739-0cec7a3a1fc1"), "Andrew Phan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2225.6999999999998, new Guid("2b1e6481-0c73-434e-8756-061e20e16d70"), new Guid("8606b885-bde6-4572-8c75-9e714858cf67"), null, new Guid("45d8f01c-5bca-4267-8d68-5f8f983fedc6"), false, false, false, new Guid("29d35a08-3e09-4108-bef4-419b007dcb38"), new Guid("03e9993b-b782-4e84-81a9-f9489cb4a689"), 2525.6999999999998, 2859.5999999999999, "MT001", 300.0, "Andrew Phan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0 });

            migrationBuilder.InsertData(
                table: "OvenEquipments",
                columns: new[] { "Id", "Code", "CreatedAtUtc", "ManufactureDate", "Name", "UpdatedAtUtc" },
                values: new object[] { new Guid("226b5d9f-3e75-4b6a-9d46-62725d947f90"), "01Ove", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oven", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Preparations",
                columns: new[] { "Id", "BalanceId", "CreatedAtUtc", "DryingTemperature", "MaterialExcluded", "Method", "UpdatedAtUtc", "VisualNomialPraticalSize" },
                values: new object[] { new Guid("2b1e6481-0c73-434e-8756-061e20e16d70"), new Guid("a50bf529-1712-44a8-b12d-d86e336fcf0c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100.0, null, "B", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0 });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Code", "CreatedAtUtc", "Name", "UpdatedAtUtc" },
                values: new object[] { new Guid("8606b885-bde6-4572-8c75-9e714858cf67"), "AAA123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adelaide Agriculture", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Samples",
                columns: new[] { "Id", "CreatedAtUtc", "Name", "ProjectId", "SampledBy", "SampledDate", "UpdatedAtUtc" },
                values: new object[] { new Guid("45d8f01c-5bca-4267-8d68-5f8f983fedc6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Barossa Soil ", new Guid("8606b885-bde6-4572-8c75-9e714858cf67"), "Andrew Phan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "SourceMaterials",
                columns: new[] { "Id", "CreatedAtUtc", "MaterialDesciption", "SourceName", "UpdatedAtUtc" },
                values: new object[] { new Guid("29d35a08-3e09-4108-bef4-419b007dcb38"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Soil and Rock", "Source01", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "Code", "CreatedAtUtc", "Name", "UpdatedAtUtc" },
                values: new object[] { new Guid("03e9993b-b782-4e84-81a9-f9489cb4a689"), "01Spec", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Specification01", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BalanceEquipments");

            migrationBuilder.DropTable(
                name: "MoistureContents");

            migrationBuilder.DropTable(
                name: "OvenEquipments");

            migrationBuilder.DropTable(
                name: "Preparations");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Samples");

            migrationBuilder.DropTable(
                name: "SourceMaterials");

            migrationBuilder.DropTable(
                name: "Specifications");
        }
    }
}
