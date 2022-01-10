using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gatitos.Migrations
{
    public partial class vacunas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vacuna_Mascotas_MascotaId",
                table: "vacuna");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vacuna",
                table: "vacuna");

            migrationBuilder.RenameTable(
                name: "vacuna",
                newName: "Vacunas");

            migrationBuilder.RenameIndex(
                name: "IX_vacuna_MascotaId",
                table: "Vacunas",
                newName: "IX_Vacunas_MascotaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vacunas",
                table: "Vacunas",
                column: "VacunaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacunas_Mascotas_MascotaId",
                table: "Vacunas",
                column: "MascotaId",
                principalTable: "Mascotas",
                principalColumn: "MascotaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacunas_Mascotas_MascotaId",
                table: "Vacunas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vacunas",
                table: "Vacunas");

            migrationBuilder.RenameTable(
                name: "Vacunas",
                newName: "vacuna");

            migrationBuilder.RenameIndex(
                name: "IX_Vacunas_MascotaId",
                table: "vacuna",
                newName: "IX_vacuna_MascotaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_vacuna",
                table: "vacuna",
                column: "VacunaId");

            migrationBuilder.AddForeignKey(
                name: "FK_vacuna_Mascotas_MascotaId",
                table: "vacuna",
                column: "MascotaId",
                principalTable: "Mascotas",
                principalColumn: "MascotaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
