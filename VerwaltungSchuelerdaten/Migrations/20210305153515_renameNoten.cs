using Microsoft.EntityFrameworkCore.Migrations;

namespace VerwaltungSchuelerdaten.Migrations
{
    public partial class renameNoten : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Note_SchuelerDaten_SchuelerID",
                table: "Note");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Note",
                table: "Note");

            migrationBuilder.RenameTable(
                name: "Note",
                newName: "Noten");

            migrationBuilder.RenameIndex(
                name: "IX_Note_SchuelerID",
                table: "Noten",
                newName: "IX_Noten_SchuelerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Noten",
                table: "Noten",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Noten_SchuelerDaten_SchuelerID",
                table: "Noten",
                column: "SchuelerID",
                principalTable: "SchuelerDaten",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noten_SchuelerDaten_SchuelerID",
                table: "Noten");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Noten",
                table: "Noten");

            migrationBuilder.RenameTable(
                name: "Noten",
                newName: "Note");

            migrationBuilder.RenameIndex(
                name: "IX_Noten_SchuelerID",
                table: "Note",
                newName: "IX_Note_SchuelerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Note",
                table: "Note",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_SchuelerDaten_SchuelerID",
                table: "Note",
                column: "SchuelerID",
                principalTable: "SchuelerDaten",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
