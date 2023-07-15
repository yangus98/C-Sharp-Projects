using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EseFilmsGiusto.Migrations
{
    /// <inheritdoc />
    public partial class iniziale2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Locandina",
                table: "Films");

            migrationBuilder.AddColumn<string>(
                name: "NomeLocandina",
                table: "Films",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeLocandina",
                table: "Films");

            migrationBuilder.AddColumn<string>(
                name: "Locandina",
                table: "Films",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
