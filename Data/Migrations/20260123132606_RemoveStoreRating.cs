using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStoreRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Store_Rating_Boundaries",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Stores");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "Stores",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Store_Rating_Boundaries",
                table: "Stores",
                sql: "[Rating] >= 0.0 AND [Rating] <= 5.0");
        }
    }
}
