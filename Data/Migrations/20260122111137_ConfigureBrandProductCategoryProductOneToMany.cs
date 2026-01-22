using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureBrandProductCategoryProductOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BrandProductCategoryId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandProductCategoryId",
                table: "Products",
                column: "BrandProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_BrandProductCategories_BrandProductCategoryId",
                table: "Products",
                column: "BrandProductCategoryId",
                principalTable: "BrandProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_BrandProductCategories_BrandProductCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_BrandProductCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BrandProductCategoryId",
                table: "Products");
        }
    }
}
