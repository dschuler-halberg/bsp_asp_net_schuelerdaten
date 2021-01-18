using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VerwaltungSchuelerdaten.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SchuelerDaten",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vorname = table.Column<string>(nullable: true),
                    Nachname = table.Column<string>(nullable: true),
                    Geburtsdatum = table.Column<DateTime>(nullable: false),
                    EMail = table.Column<string>(nullable: true),
                    Telefonnummer = table.Column<string>(nullable: true),
                    Konfession = table.Column<string>(nullable: true),
                    Staatsangehoerigkeit = table.Column<string>(nullable: true),
                    ZweiteStaatsangehoerigkeit = table.Column<string>(nullable: true),
                    Anmeldedatum = table.Column<DateTime>(nullable: false),
                    Kommentar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchuelerDaten", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchuelerDaten");
        }
    }
}
