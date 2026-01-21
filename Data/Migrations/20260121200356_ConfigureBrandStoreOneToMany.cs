using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureBrandStoreOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BrandId",
                table: "Stores",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Stores_BrandId",
                table: "Stores",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Brands_BrandId",
                table: "Stores",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Brands_BrandId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_BrandId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Stores");
        }
    }
}
