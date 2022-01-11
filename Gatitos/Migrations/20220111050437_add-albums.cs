using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gatitos.Migrations
{
    public partial class addalbums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Mascotas_MascotaId",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Galeria_Album_AlbumId",
                table: "Galeria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Galeria",
                table: "Galeria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Album",
                table: "Album");

            migrationBuilder.RenameTable(
                name: "Galeria",
                newName: "Galerias");

            migrationBuilder.RenameTable(
                name: "Album",
                newName: "Albums");

            migrationBuilder.RenameIndex(
                name: "IX_Galeria_AlbumId",
                table: "Galerias",
                newName: "IX_Galerias_AlbumId");

            migrationBuilder.RenameIndex(
                name: "IX_Album_MascotaId",
                table: "Albums",
                newName: "IX_Albums_MascotaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Galerias",
                table: "Galerias",
                column: "GaleriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Albums",
                table: "Albums",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Mascotas_MascotaId",
                table: "Albums",
                column: "MascotaId",
                principalTable: "Mascotas",
                principalColumn: "MascotaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Galerias_Albums_AlbumId",
                table: "Galerias",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Mascotas_MascotaId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Galerias_Albums_AlbumId",
                table: "Galerias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Galerias",
                table: "Galerias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Albums",
                table: "Albums");

            migrationBuilder.RenameTable(
                name: "Galerias",
                newName: "Galeria");

            migrationBuilder.RenameTable(
                name: "Albums",
                newName: "Album");

            migrationBuilder.RenameIndex(
                name: "IX_Galerias_AlbumId",
                table: "Galeria",
                newName: "IX_Galeria_AlbumId");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_MascotaId",
                table: "Album",
                newName: "IX_Album_MascotaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Galeria",
                table: "Galeria",
                column: "GaleriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Album",
                table: "Album",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Mascotas_MascotaId",
                table: "Album",
                column: "MascotaId",
                principalTable: "Mascotas",
                principalColumn: "MascotaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Galeria_Album_AlbumId",
                table: "Galeria",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
