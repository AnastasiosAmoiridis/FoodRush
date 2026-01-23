using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeCodeAndCodeDefinitionDescriptionAlternateKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Codes_Name",
                table: "Codes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Codes");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Codes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Codes_Description",
                table: "Codes",
                column: "Description");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CodeDefinitions_Description",
                table: "CodeDefinitions",
                column: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Codes_Description",
                table: "Codes");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_CodeDefinitions_Description",
                table: "CodeDefinitions");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Codes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Codes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Codes_Name",
                table: "Codes",
                column: "Name");
        }
    }
}
