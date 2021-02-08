using Microsoft.EntityFrameworkCore.Migrations;

namespace VerwaltungSchuelerdaten.Migrations
{
    public partial class klasse_hinzugefuegt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klasse",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Beschreibung = table.Column<string>(nullable: true),
                    KlassenSprecherInID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klasse", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Klasse_SchuelerDaten_KlassenSprecherInID",
                        column: x => x.KlassenSprecherInID,
                        principalTable: "SchuelerDaten",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Klasse_KlassenSprecherInID",
                table: "Klasse",
                column: "KlassenSprecherInID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Klasse");
        }
    }
}
