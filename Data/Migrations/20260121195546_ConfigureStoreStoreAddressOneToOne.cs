using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureStoreStoreAddressOneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StoreAddressId",
                table: "Stores",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "StoreAddresses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_StoreAddresses_StoreId",
                table: "StoreAddresses",
                column: "StoreId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreAddresses_Stores_StoreId",
                table: "StoreAddresses",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreAddresses_Stores_StoreId",
                table: "StoreAddresses");

            migrationBuilder.DropIndex(
                name: "IX_StoreAddresses_StoreId",
                table: "StoreAddresses");

            migrationBuilder.DropColumn(
                name: "StoreAddressId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "StoreAddresses");
        }
    }
}
