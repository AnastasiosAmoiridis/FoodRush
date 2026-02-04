using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.AuthMigrations
{
    /// <inheritdoc />
    public partial class ConfigureRefreshTokenHasRefreshTokenReplacementOneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ReplacedByTokenId",
                table: "RefreshTokens",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_ReplacedByTokenId",
                table: "RefreshTokens",
                column: "ReplacedByTokenId",
                unique: true,
                filter: "[ReplacedByTokenId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_RefreshTokens_ReplacedByTokenId",
                table: "RefreshTokens",
                column: "ReplacedByTokenId",
                principalTable: "RefreshTokens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_RefreshTokens_ReplacedByTokenId",
                table: "RefreshTokens");

            migrationBuilder.DropIndex(
                name: "IX_RefreshTokens_ReplacedByTokenId",
                table: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "ReplacedByTokenId",
                table: "RefreshTokens");
        }
    }
}
