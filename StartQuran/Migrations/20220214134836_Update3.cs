using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StartQuran.Migrations
{
    public partial class Update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentTeachers_AspNetUsers_TeacherId1",
                table: "StudentTeachers");

            migrationBuilder.DropIndex(
                name: "IX_StudentTeachers_TeacherId1",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "TeacherId1",
                table: "StudentTeachers");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "StudentTeachers",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTeachers_TeacherId",
                table: "StudentTeachers",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTeachers_AspNetUsers_TeacherId",
                table: "StudentTeachers",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentTeachers_AspNetUsers_TeacherId",
                table: "StudentTeachers");

            migrationBuilder.DropIndex(
                name: "IX_StudentTeachers_TeacherId",
                table: "StudentTeachers");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeacherId",
                table: "StudentTeachers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherId1",
                table: "StudentTeachers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentTeachers_TeacherId1",
                table: "StudentTeachers",
                column: "TeacherId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTeachers_AspNetUsers_TeacherId1",
                table: "StudentTeachers",
                column: "TeacherId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
