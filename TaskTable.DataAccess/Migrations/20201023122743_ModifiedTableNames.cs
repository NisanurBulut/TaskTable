using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTable.DataAccess.Migrations
{
    public partial class ModifiedTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "tKullanici",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(maxLength: 50, nullable: false),
                    Soyad = table.Column<string>(maxLength: 50, nullable: false),
                    Telefon = table.Column<string>(maxLength: 11, nullable: false),
                    Eposta = table.Column<string>(maxLength: 150, nullable: false),
                    DogumTarihi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tKullanici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tCalisma",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(maxLength: 50, nullable: false),
                    Durum = table.Column<bool>(nullable: false),
                    Aciklama = table.Column<string>(maxLength: 150, nullable: false),
                    OlusturulmaTarihi = table.Column<DateTime>(nullable: false),
                    KullaniciId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tCalisma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tCalisma_tKullanici_KullaniciId",
                        column: x => x.KullaniciId,
                        principalSchema: "dbo",
                        principalTable: "tKullanici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tCalisma_KullaniciId",
                schema: "dbo",
                table: "tCalisma",
                column: "KullaniciId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tCalisma",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tKullanici",
                schema: "dbo");
        }
    }
}
