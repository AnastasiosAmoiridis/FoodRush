using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureOrderHeaderPaymentCodeOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PaymentCodeId",
                table: "OrderHeaders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_PaymentCodeId",
                table: "OrderHeaders",
                column: "PaymentCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeaders_Codes_PaymentCodeId",
                table: "OrderHeaders",
                column: "PaymentCodeId",
                principalTable: "Codes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeaders_Codes_PaymentCodeId",
                table: "OrderHeaders");

            migrationBuilder.DropIndex(
                name: "IX_OrderHeaders_PaymentCodeId",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "PaymentCodeId",
                table: "OrderHeaders");
        }
    }
}
