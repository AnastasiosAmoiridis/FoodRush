using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureGlobalFilterProductOverrideManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GlobalFilterProductOverrides",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GlobalFilterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NewFilterConfig = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalFilterProductOverrides", x => new { x.ProductId, x.GlobalFilterId });
                    table.ForeignKey(
                        name: "FK_GlobalFilterProductOverrides_GlobalFilters_GlobalFilterId",
                        column: x => x.GlobalFilterId,
                        principalTable: "GlobalFilters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GlobalFilterProductOverrides_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GlobalFilterProductOverrides_GlobalFilterId",
                table: "GlobalFilterProductOverrides",
                column: "GlobalFilterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlobalFilterProductOverrides");
        }
    }
}
