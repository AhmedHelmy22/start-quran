using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StartQuran.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "StudentTeachers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "StudentTeachers",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "StudentTeachers",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StudentTeachers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserCreate",
                table: "StudentTeachers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserDelete",
                table: "StudentTeachers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserEdit",
                table: "StudentTeachers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "UserCreate",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "UserDelete",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "UserEdit",
                table: "StudentTeachers");
        }
    }
}
