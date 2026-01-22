using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureBrandProductCategoryGlobalProductCategoryOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GlobalProductCategoryId",
                table: "BrandProductCategories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BrandProductCategories_GlobalProductCategoryId",
                table: "BrandProductCategories",
                column: "GlobalProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandProductCategories_GlobalProductCategories_GlobalProductCategoryId",
                table: "BrandProductCategories",
                column: "GlobalProductCategoryId",
                principalTable: "GlobalProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrandProductCategories_GlobalProductCategories_GlobalProductCategoryId",
                table: "BrandProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_BrandProductCategories_GlobalProductCategoryId",
                table: "BrandProductCategories");

            migrationBuilder.DropColumn(
                name: "GlobalProductCategoryId",
                table: "BrandProductCategories");
        }
    }
}
