using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InvertCodeCodeDefinitionRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "CodeDefinitionId",
                table: "Codes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Codes_CodeDefinitionId",
                table: "Codes",
                column: "CodeDefinitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Codes_CodeDefinitions_CodeDefinitionId",
                table: "Codes",
                column: "CodeDefinitionId",
                principalTable: "CodeDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Codes_CodeDefinitions_CodeDefinitionId",
                table: "Codes");

            migrationBuilder.DropIndex(
                name: "IX_Codes_CodeDefinitionId",
                table: "Codes");

            migrationBuilder.DropColumn(
                name: "CodeDefinitionId",
                table: "Codes");

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
    }
}
