using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddedOvenAndWetMassColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OvenId",
                table: "Preparations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MaterialWetMass",
                table: "MoistureContents",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Preparations_OvenId",
                table: "Preparations",
                column: "OvenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Preparations_OvenEquipments_OvenId",
                table: "Preparations",
                column: "OvenId",
                principalTable: "OvenEquipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Preparations_OvenEquipments_OvenId",
                table: "Preparations");

            migrationBuilder.DropIndex(
                name: "IX_Preparations_OvenId",
                table: "Preparations");

            migrationBuilder.DropColumn(
                name: "OvenId",
                table: "Preparations");

            migrationBuilder.DropColumn(
                name: "MaterialWetMass",
                table: "MoistureContents");
        }
    }
}
