using Microsoft.EntityFrameworkCore.Migrations;

namespace VerwaltungSchuelerdaten.Migrations
{
    public partial class added_grades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Vorname",
                table: "SchuelerDaten",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nachname",
                table: "SchuelerDaten",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notenwert = table.Column<int>(nullable: false),
                    Beschreibung = table.Column<string>(nullable: true),
                    SchuelerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Note_SchuelerDaten_SchuelerID",
                        column: x => x.SchuelerID,
                        principalTable: "SchuelerDaten",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Note_SchuelerID",
                table: "Note",
                column: "SchuelerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.AlterColumn<string>(
                name: "Vorname",
                table: "SchuelerDaten",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Nachname",
                table: "SchuelerDaten",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
