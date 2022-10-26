using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCTagHelper.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Landen",
                columns: table => new
                {
                    LandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LandCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandNaam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landen", x => x.LandId);
                });

            migrationBuilder.CreateTable(
                name: "Locaties",
                columns: table => new
                {
                    LocatieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locaties", x => x.LocatieId);
                    table.ForeignKey(
                        name: "FK_Locaties_Landen_LandId",
                        column: x => x.LandId,
                        principalTable: "Landen",
                        principalColumn: "LandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Afdelingen",
                columns: table => new
                {
                    AfdelingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AfdelingNaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocatieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afdelingen", x => x.AfdelingId);
                    table.ForeignKey(
                        name: "FK_Afdelingen_Locaties_LocatieId",
                        column: x => x.LocatieId,
                        principalTable: "Locaties",
                        principalColumn: "LocatieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Afdelingen_LocatieId",
                table: "Afdelingen",
                column: "LocatieId");

            migrationBuilder.CreateIndex(
                name: "IX_Locaties_LandId",
                table: "Locaties",
                column: "LandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Afdelingen");

            migrationBuilder.DropTable(
                name: "Locaties");

            migrationBuilder.DropTable(
                name: "Landen");
        }
    }
}
