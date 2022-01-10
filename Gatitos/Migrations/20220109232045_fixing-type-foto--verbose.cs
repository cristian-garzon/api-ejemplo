using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gatitos.Migrations
{
    public partial class fixingtypefotoverbose : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascota_Personas_PersonaId",
                table: "Mascota");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mascota",
                table: "Mascota");

            migrationBuilder.RenameTable(
                name: "Mascota",
                newName: "Mascotas");

            migrationBuilder.RenameColumn(
                name: "foto",
                table: "Mascotas",
                newName: "Foto");

            migrationBuilder.RenameIndex(
                name: "IX_Mascota_PersonaId",
                table: "Mascotas",
                newName: "IX_Mascotas_PersonaId");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Foto",
                table: "Mascotas",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mascotas",
                table: "Mascotas",
                column: "MascotaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Personas_PersonaId",
                table: "Mascotas",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "PersonaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Personas_PersonaId",
                table: "Mascotas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mascotas",
                table: "Mascotas");

            migrationBuilder.RenameTable(
                name: "Mascotas",
                newName: "Mascota");

            migrationBuilder.RenameColumn(
                name: "Foto",
                table: "Mascota",
                newName: "foto");

            migrationBuilder.RenameIndex(
                name: "IX_Mascotas_PersonaId",
                table: "Mascota",
                newName: "IX_Mascota_PersonaId");

            migrationBuilder.AlterColumn<byte>(
                name: "foto",
                table: "Mascota",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mascota",
                table: "Mascota",
                column: "MascotaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascota_Personas_PersonaId",
                table: "Mascota",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "PersonaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
