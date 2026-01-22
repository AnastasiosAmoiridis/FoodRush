using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureBrandBrandProductCategoryOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BrandId",
                table: "BrandProductCategories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BrandProductCategories_BrandId",
                table: "BrandProductCategories",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandProductCategories_Brands_BrandId",
                table: "BrandProductCategories",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrandProductCategories_Brands_BrandId",
                table: "BrandProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_BrandProductCategories_BrandId",
                table: "BrandProductCategories");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "BrandProductCategories");
        }
    }
}
