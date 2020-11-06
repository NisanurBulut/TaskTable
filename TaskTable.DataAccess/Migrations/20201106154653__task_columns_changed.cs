using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTable.DataAccess.Migrations
{
    public partial class _task_columns_changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aciklama",
                schema: "dbo",
                table: "tTask");

            migrationBuilder.DropColumn(
                name: "Ad",
                schema: "dbo",
                table: "tTask");

            migrationBuilder.DropColumn(
                name: "Durum",
                schema: "dbo",
                table: "tTask");

            migrationBuilder.DropColumn(
                name: "OlusturulmaTarihi",
                schema: "dbo",
                table: "tTask");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                schema: "dbo",
                table: "tTask",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "tTask",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "tTask",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "State",
                schema: "dbo",
                table: "tTask",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                schema: "dbo",
                table: "tTask");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "dbo",
                table: "tTask");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "dbo",
                table: "tTask");

            migrationBuilder.DropColumn(
                name: "State",
                schema: "dbo",
                table: "tTask");

            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                schema: "dbo",
                table: "tTask",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ad",
                schema: "dbo",
                table: "tTask",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Durum",
                schema: "dbo",
                table: "tTask",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "OlusturulmaTarihi",
                schema: "dbo",
                table: "tTask",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
