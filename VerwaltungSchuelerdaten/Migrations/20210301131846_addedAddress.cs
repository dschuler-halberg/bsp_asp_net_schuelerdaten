using Microsoft.EntityFrameworkCore.Migrations;

namespace VerwaltungSchuelerdaten.Migrations
{
    public partial class addedAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdresseID",
                table: "SchuelerDaten",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Adresse",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ort = table.Column<string>(nullable: true),
                    Strasse = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresse", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchuelerDaten_AdresseID",
                table: "SchuelerDaten",
                column: "AdresseID");

            migrationBuilder.AddForeignKey(
                name: "FK_SchuelerDaten_Adresse_AdresseID",
                table: "SchuelerDaten",
                column: "AdresseID",
                principalTable: "Adresse",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchuelerDaten_Adresse_AdresseID",
                table: "SchuelerDaten");

            migrationBuilder.DropTable(
                name: "Adresse");

            migrationBuilder.DropIndex(
                name: "IX_SchuelerDaten_AdresseID",
                table: "SchuelerDaten");

            migrationBuilder.DropColumn(
                name: "AdresseID",
                table: "SchuelerDaten");
        }
    }
}
