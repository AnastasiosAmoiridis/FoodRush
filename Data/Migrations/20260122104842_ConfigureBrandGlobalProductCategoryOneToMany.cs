using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureBrandGlobalProductCategoryOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PrimaryProductCategoryId",
                table: "Brands",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Brands_PrimaryProductCategoryId",
                table: "Brands",
                column: "PrimaryProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_GlobalProductCategories_PrimaryProductCategoryId",
                table: "Brands",
                column: "PrimaryProductCategoryId",
                principalTable: "GlobalProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_GlobalProductCategories_PrimaryProductCategoryId",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brands_PrimaryProductCategoryId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "PrimaryProductCategoryId",
                table: "Brands");
        }
    }
}
