using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureOrderHeaderOrderStatusCodeOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderStatusCodeId",
                table: "OrderHeaders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_OrderStatusCodeId",
                table: "OrderHeaders",
                column: "OrderStatusCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeaders_Codes_OrderStatusCodeId",
                table: "OrderHeaders",
                column: "OrderStatusCodeId",
                principalTable: "Codes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeaders_Codes_OrderStatusCodeId",
                table: "OrderHeaders");

            migrationBuilder.DropIndex(
                name: "IX_OrderHeaders_OrderStatusCodeId",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "OrderStatusCodeId",
                table: "OrderHeaders");
        }
    }
}
