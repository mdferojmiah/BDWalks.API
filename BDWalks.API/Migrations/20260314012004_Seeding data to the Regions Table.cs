using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BDWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdatatotheRegionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrll" },
                values: new object[,]
                {
                    { new Guid("15d083e1-d140-4401-8227-1c73084fc2bc"), "MNS", "Mymensingh", "http://dummyimage.com/159x100.png/ff4444/ffffff" },
                    { new Guid("1a087eb9-a88e-40f5-b524-a9a933b2d281"), "RNP", "Rangpur", "http://dummyimage.com/204x100.png/dddddd/000000" },
                    { new Guid("42bb729a-81f6-4b0a-b7bf-ff99f5d86024"), "DHK", "Dhaka", "http://dummyimage.com/228x100.png/cc0000/ffffff" },
                    { new Guid("4b4f56b0-e6ca-4201-bd4f-8d380e95c7a7"), "RJH", "Rajshahi", "http://dummyimage.com/161x100.png/dddddd/000000" },
                    { new Guid("7724d32a-8cae-4fa8-b2f7-ae9255e3c12d"), "SLT", "Sylhet", "http://dummyimage.com/182x100.png/ff4444/ffffff" },
                    { new Guid("952175e9-f4ee-45b7-a551-ce1a88aaa66b"), "BSL", "Barishal", "http://dummyimage.com/205x100.png/5fa2dd/ffffff" },
                    { new Guid("ca440154-92dd-45bb-8ccb-b44ac96718dd"), "KLN", "Khulna", "http://dummyimage.com/230x100.png/5fa2dd/ffffff" },
                    { new Guid("e3e9e8da-c649-47c9-9273-e0addeff942b"), "CTG", "Chattogram", "http://dummyimage.com/101x100.png/dddddd/000000" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("15d083e1-d140-4401-8227-1c73084fc2bc"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1a087eb9-a88e-40f5-b524-a9a933b2d281"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("42bb729a-81f6-4b0a-b7bf-ff99f5d86024"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4b4f56b0-e6ca-4201-bd4f-8d380e95c7a7"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7724d32a-8cae-4fa8-b2f7-ae9255e3c12d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("952175e9-f4ee-45b7-a551-ce1a88aaa66b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ca440154-92dd-45bb-8ccb-b44ac96718dd"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e3e9e8da-c649-47c9-9273-e0addeff942b"));
        }
    }
}
