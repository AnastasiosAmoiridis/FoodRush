using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCodeDefinition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CodeDefinitions",
                columns: new[] { "Id", "Description", "IsActive", "IsDeleted" },
                values: new object[,]
                {
                    { new Guid("3c9e1f72-0a5d-4e8b-b7a4-9d6f2c1e4b22"), "OrderStatus", true, false },
                    { new Guid("8f2a6c3e-4b91-4d6c-9c3f-1a7e9f2b0a11"), "Payment", true, false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CodeDefinitions",
                keyColumn: "Id",
                keyValue: new Guid("3c9e1f72-0a5d-4e8b-b7a4-9d6f2c1e4b22"));

            migrationBuilder.DeleteData(
                table: "CodeDefinitions",
                keyColumn: "Id",
                keyValue: new Guid("8f2a6c3e-4b91-4d6c-9c3f-1a7e9f2b0a11"));
        }
    }
}
