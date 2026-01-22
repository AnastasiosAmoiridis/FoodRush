using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureGlobalFilterBrandProductCategoryOverrideManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GlobalFilterBrandCategoryOverrides",
                columns: table => new
                {
                    GlobalFilterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandProductCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NewFilterConfig = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalFilterBrandCategoryOverrides", x => new { x.BrandProductCategoryId, x.GlobalFilterId });
                    table.ForeignKey(
                        name: "FK_GlobalFilterBrandCategoryOverrides_BrandProductCategories_BrandProductCategoryId",
                        column: x => x.BrandProductCategoryId,
                        principalTable: "BrandProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GlobalFilterBrandCategoryOverrides_GlobalFilters_GlobalFilterId",
                        column: x => x.GlobalFilterId,
                        principalTable: "GlobalFilters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GlobalFilterBrandCategoryOverrides_GlobalFilterId",
                table: "GlobalFilterBrandCategoryOverrides",
                column: "GlobalFilterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlobalFilterBrandCategoryOverrides");
        }
    }
}
