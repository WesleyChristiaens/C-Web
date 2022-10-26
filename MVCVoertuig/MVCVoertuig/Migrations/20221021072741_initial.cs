using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCVoertuig.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Voertuigen",
                columns: table => new
                {
                    VoertuigId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Merk = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MerkType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Bouwjaar = table.Column<int>(type: "int", nullable: false),
                    Km = table.Column<int>(type: "int", nullable: false),
                    VerkoopPrijs = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    AanwezigInShowroom = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voertuigen", x => x.VoertuigId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voertuigen");
        }
    }
}
