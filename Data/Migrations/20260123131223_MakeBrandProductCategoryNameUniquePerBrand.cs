using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeBrandProductCategoryNameUniquePerBrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BrandProductCategories_Name_BrandId",
                table: "BrandProductCategories",
                columns: new[] { "Name", "BrandId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BrandProductCategories_Name_BrandId",
                table: "BrandProductCategories");
        }
    }
}
