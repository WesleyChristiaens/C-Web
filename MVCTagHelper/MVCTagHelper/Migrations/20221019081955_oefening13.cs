using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCTagHelper.Migrations
{
    public partial class oefening13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medewerker",
                columns: table => new
                {
                    MedeWerkerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AfdelingId = table.Column<int>(type: "int", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medewerker", x => x.MedeWerkerId);
                    table.ForeignKey(
                        name: "FK_Medewerker_Afdelingen_AfdelingId",
                        column: x => x.AfdelingId,
                        principalTable: "Afdelingen",
                        principalColumn: "AfdelingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medewerker_AfdelingId",
                table: "Medewerker",
                column: "AfdelingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medewerker");
        }
    }
}
