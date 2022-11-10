using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCGroentenEnFruit.Migrations
{
    public partial class aankoop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "AankoopOrders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AankoopOrders_IdentityUserId",
                table: "AankoopOrders",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AankoopOrders_AspNetUsers_IdentityUserId",
                table: "AankoopOrders",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AankoopOrders_AspNetUsers_IdentityUserId",
                table: "AankoopOrders");

            migrationBuilder.DropIndex(
                name: "IX_AankoopOrders_IdentityUserId",
                table: "AankoopOrders");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "AankoopOrders");
        }
    }
}
