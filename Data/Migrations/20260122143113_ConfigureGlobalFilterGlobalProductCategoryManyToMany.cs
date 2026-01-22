using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureGlobalFilterGlobalProductCategoryManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GlobalFilterGlobalCategories",
                columns: table => new
                {
                    GlobalFilterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GlobalProductCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalFilterGlobalCategories", x => new { x.GlobalProductCategoryId, x.GlobalFilterId });
                    table.ForeignKey(
                        name: "FK_GlobalFilterGlobalCategories_GlobalFilters_GlobalFilterId",
                        column: x => x.GlobalFilterId,
                        principalTable: "GlobalFilters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GlobalFilterGlobalCategories_GlobalProductCategories_GlobalProductCategoryId",
                        column: x => x.GlobalProductCategoryId,
                        principalTable: "GlobalProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GlobalFilterGlobalCategories_GlobalFilterId",
                table: "GlobalFilterGlobalCategories",
                column: "GlobalFilterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlobalFilterGlobalCategories");
        }
    }
}
