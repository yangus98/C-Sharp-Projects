using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebConcessionaria.Migrations
{
    /// <inheritdoc />
    public partial class Iniziale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CasaProduttrice = table.Column<int>(type: "int", nullable: false),
                    Modello = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Prezzo = table.Column<int>(type: "int", nullable: false),
                    AnnoUscita = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autos");
        }
    }
}
