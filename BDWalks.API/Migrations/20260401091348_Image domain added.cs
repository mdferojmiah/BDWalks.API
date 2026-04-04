using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class Imagedomainadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegionImageUrll",
                table: "Regions",
                newName: "RegionImageUrl");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("15d083e1-d140-4401-8227-1c73084fc2bc"),
                column: "RegionImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1a087eb9-a88e-40f5-b524-a9a933b2d281"),
                column: "RegionImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("42bb729a-81f6-4b0a-b7bf-ff99f5d86024"),
                column: "RegionImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4b4f56b0-e6ca-4201-bd4f-8d380e95c7a7"),
                column: "RegionImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7724d32a-8cae-4fa8-b2f7-ae9255e3c12d"),
                column: "RegionImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("952175e9-f4ee-45b7-a551-ce1a88aaa66b"),
                column: "RegionImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ca440154-92dd-45bb-8ccb-b44ac96718dd"),
                column: "RegionImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e3e9e8da-c649-47c9-9273-e0addeff942b"),
                column: "RegionImageUrl",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.RenameColumn(
                name: "RegionImageUrl",
                table: "Regions",
                newName: "RegionImageUrll");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("15d083e1-d140-4401-8227-1c73084fc2bc"),
                column: "RegionImageUrll",
                value: "http://dummyimage.com/159x100.png/ff4444/ffffff");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1a087eb9-a88e-40f5-b524-a9a933b2d281"),
                column: "RegionImageUrll",
                value: "http://dummyimage.com/204x100.png/dddddd/000000");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("42bb729a-81f6-4b0a-b7bf-ff99f5d86024"),
                column: "RegionImageUrll",
                value: "http://dummyimage.com/228x100.png/cc0000/ffffff");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4b4f56b0-e6ca-4201-bd4f-8d380e95c7a7"),
                column: "RegionImageUrll",
                value: "http://dummyimage.com/161x100.png/dddddd/000000");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7724d32a-8cae-4fa8-b2f7-ae9255e3c12d"),
                column: "RegionImageUrll",
                value: "http://dummyimage.com/182x100.png/ff4444/ffffff");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("952175e9-f4ee-45b7-a551-ce1a88aaa66b"),
                column: "RegionImageUrll",
                value: "http://dummyimage.com/205x100.png/5fa2dd/ffffff");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ca440154-92dd-45bb-8ccb-b44ac96718dd"),
                column: "RegionImageUrll",
                value: "http://dummyimage.com/230x100.png/5fa2dd/ffffff");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e3e9e8da-c649-47c9-9273-e0addeff942b"),
                column: "RegionImageUrll",
                value: "http://dummyimage.com/101x100.png/dddddd/000000");
        }
    }
}
