using Microsoft.EntityFrameworkCore.Migrations;

namespace VerwaltungSchuelerdaten.Migrations
{
    public partial class rename_klasse_klassen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klasse_SchuelerDaten_KlassenSprecherInID",
                table: "Klasse");

            migrationBuilder.DropForeignKey(
                name: "FK_SchuelerDaten_Klasse_KlasseID",
                table: "SchuelerDaten");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Klasse",
                table: "Klasse");

            migrationBuilder.RenameTable(
                name: "Klasse",
                newName: "Klassen");

            migrationBuilder.RenameIndex(
                name: "IX_Klasse_KlassenSprecherInID",
                table: "Klassen",
                newName: "IX_Klassen_KlassenSprecherInID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Klassen",
                table: "Klassen",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Klassen_SchuelerDaten_KlassenSprecherInID",
                table: "Klassen",
                column: "KlassenSprecherInID",
                principalTable: "SchuelerDaten",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SchuelerDaten_Klassen_KlasseID",
                table: "SchuelerDaten",
                column: "KlasseID",
                principalTable: "Klassen",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klassen_SchuelerDaten_KlassenSprecherInID",
                table: "Klassen");

            migrationBuilder.DropForeignKey(
                name: "FK_SchuelerDaten_Klassen_KlasseID",
                table: "SchuelerDaten");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Klassen",
                table: "Klassen");

            migrationBuilder.RenameTable(
                name: "Klassen",
                newName: "Klasse");

            migrationBuilder.RenameIndex(
                name: "IX_Klassen_KlassenSprecherInID",
                table: "Klasse",
                newName: "IX_Klasse_KlassenSprecherInID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Klasse",
                table: "Klasse",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Klasse_SchuelerDaten_KlassenSprecherInID",
                table: "Klasse",
                column: "KlassenSprecherInID",
                principalTable: "SchuelerDaten",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SchuelerDaten_Klasse_KlasseID",
                table: "SchuelerDaten",
                column: "KlasseID",
                principalTable: "Klasse",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
