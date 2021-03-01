using Microsoft.EntityFrameworkCore.Migrations;

namespace VerwaltungSchuelerdaten.Migrations
{
    public partial class linkSchuelerKlasse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KlasseID",
                table: "SchuelerDaten",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SchuelerDaten_KlasseID",
                table: "SchuelerDaten",
                column: "KlasseID");

            migrationBuilder.AddForeignKey(
                name: "FK_SchuelerDaten_Klasse_KlasseID",
                table: "SchuelerDaten",
                column: "KlasseID",
                principalTable: "Klasse",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchuelerDaten_Klasse_KlasseID",
                table: "SchuelerDaten");

            migrationBuilder.DropIndex(
                name: "IX_SchuelerDaten_KlasseID",
                table: "SchuelerDaten");

            migrationBuilder.DropColumn(
                name: "KlasseID",
                table: "SchuelerDaten");
        }
    }
}
