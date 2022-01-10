using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gatitos.Migrations
{
    public partial class addtablemascota : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mascota",
                columns: table => new
                {
                    MascotaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Años = table.Column<int>(type: "int", nullable: false),
                    especie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    foto = table.Column<byte>(type: "tinyint", nullable: true),
                    PersonaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascota", x => x.MascotaId);
                    table.ForeignKey(
                        name: "FK_Mascota_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_PersonaId",
                table: "Mascota",
                column: "PersonaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mascota");
        }
    }
}
