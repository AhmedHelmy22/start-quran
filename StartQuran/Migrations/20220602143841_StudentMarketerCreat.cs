using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StartQuran.Migrations
{
    public partial class StudentMarketerCreat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentMarketers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UserCreate = table.Column<string>(nullable: true),
                    EditDate = table.Column<DateTime>(nullable: false),
                    UserEdit = table.Column<string>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: false),
                    UserDelete = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: false),
                    MarketerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentMarketers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentMarketers_AspNetUsers_MarketerId",
                        column: x => x.MarketerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentMarketers_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentMarketers_MarketerId",
                table: "StudentMarketers",
                column: "MarketerId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMarketers_StudentId",
                table: "StudentMarketers",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentMarketers");
        }
    }
}
