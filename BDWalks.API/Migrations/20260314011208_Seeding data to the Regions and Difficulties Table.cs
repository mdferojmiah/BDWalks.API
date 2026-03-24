using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BDWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdatatotheRegionsandDifficultiesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1d9b6815-e737-4140-af40-e89139e8c7d0"), "Medium" },
                    { new Guid("54981894-cf6c-4851-9ecb-4a6437eb643b"), "Hard" },
                    { new Guid("f0776eec-aca2-46b0-8f62-646af060854f"), "Easy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("1d9b6815-e737-4140-af40-e89139e8c7d0"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("54981894-cf6c-4851-9ecb-4a6437eb643b"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f0776eec-aca2-46b0-8f62-646af060854f"));
        }
    }
}
