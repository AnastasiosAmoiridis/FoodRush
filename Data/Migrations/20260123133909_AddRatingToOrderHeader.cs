using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRatingToOrderHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "OrderHeaders",
                type: "decimal(3,2)",
                precision: 3,
                scale: 2,
                nullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Store_Rating_Boundaries",
                table: "OrderHeaders",
                sql: "[Rating] >= 0.0 AND [Rating] <= 5.0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Store_Rating_Boundaries",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "OrderHeaders");
        }
    }
}
