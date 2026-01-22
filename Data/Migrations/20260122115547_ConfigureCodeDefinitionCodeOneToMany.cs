using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureCodeDefinitionCodeOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CodeId",
                table: "CodeDefinitions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CodeDefinitions_CodeId",
                table: "CodeDefinitions",
                column: "CodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CodeDefinitions_Codes_CodeId",
                table: "CodeDefinitions",
                column: "CodeId",
                principalTable: "Codes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CodeDefinitions_Codes_CodeId",
                table: "CodeDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_CodeDefinitions_CodeId",
                table: "CodeDefinitions");

            migrationBuilder.DropColumn(
                name: "CodeId",
                table: "CodeDefinitions");
        }
    }
}
