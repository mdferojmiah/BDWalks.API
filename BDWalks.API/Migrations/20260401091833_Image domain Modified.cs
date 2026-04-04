using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class ImagedomainModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FileSize",
                table: "Images",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "Images");
        }
    }
}
