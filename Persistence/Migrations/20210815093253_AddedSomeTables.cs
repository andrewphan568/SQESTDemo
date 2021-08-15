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

            migrationBuilder.CreateTable(
                name: "StandardTestMethods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardTestMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Preparations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DryingTemperature = table.Column<double>(type: "float", nullable: false),
                    BalanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VisualNomialPraticalSize = table.Column<double>(type: "float", nullable: false),
                    MaterialExcluded = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preparations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Preparations_BalanceEquipments_BalanceId",
                        column: x => x.BalanceId,
                        principalTable: "BalanceEquipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Samples",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SampledBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SampledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Samples_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MoistureContents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorksheetId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SourceMaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SpecificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SampleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PreparationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StandardTestMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_MoistureContents_Preparations_PreparationId",
                        column: x => x.PreparationId,
                        principalTable: "Preparations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoistureContents_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoistureContents_Samples_SampleId",
                        column: x => x.SampleId,
                        principalTable: "Samples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoistureContents_SourceMaterials_SourceMaterialId",
                        column: x => x.SourceMaterialId,
                        principalTable: "SourceMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoistureContents_Specifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoistureContents_StandardTestMethods_StandardTestMethodId",
                        column: x => x.StandardTestMethodId,
                        principalTable: "StandardTestMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoistureContents_PreparationId",
                table: "MoistureContents",
                column: "PreparationId");

            migrationBuilder.CreateIndex(
                name: "IX_MoistureContents_ProjectId",
                table: "MoistureContents",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_MoistureContents_SampleId",
                table: "MoistureContents",
                column: "SampleId");

            migrationBuilder.CreateIndex(
                name: "IX_MoistureContents_SourceMaterialId",
                table: "MoistureContents",
                column: "SourceMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MoistureContents_SpecificationId",
                table: "MoistureContents",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_MoistureContents_StandardTestMethodId",
                table: "MoistureContents",
                column: "StandardTestMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Preparations_BalanceId",
                table: "Preparations",
                column: "BalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Samples_ProjectId",
                table: "Samples",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoistureContents");

            migrationBuilder.DropTable(
                name: "OvenEquipments");

            migrationBuilder.DropTable(
                name: "Preparations");

            migrationBuilder.DropTable(
                name: "Samples");

            migrationBuilder.DropTable(
                name: "SourceMaterials");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropTable(
                name: "StandardTestMethods");

            migrationBuilder.DropTable(
                name: "BalanceEquipments");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
