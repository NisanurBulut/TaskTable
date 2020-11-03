using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTable.DataAccess.Migrations
{
    public partial class add_table_tNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tNotification",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AppUserId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    State = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tNotification_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tNotification_AppUserId",
                schema: "dbo",
                table: "tNotification",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tNotification",
                schema: "dbo");
        }
    }
}
