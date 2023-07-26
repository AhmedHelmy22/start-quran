using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StartQuran.Migrations
{
    public partial class moderator1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModeratorSupervisor",
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
                    SupervisorId = table.Column<string>(nullable: true),
                    ModeratorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeratorSupervisor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ModeratorSupervisor_AspNetUsers_ModeratorId",
                        column: x => x.ModeratorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModeratorSupervisor_AspNetUsers_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModeratorSupervisor_ModeratorId",
                table: "ModeratorSupervisor",
                column: "ModeratorId");

            migrationBuilder.CreateIndex(
                name: "IX_ModeratorSupervisor_SupervisorId",
                table: "ModeratorSupervisor",
                column: "SupervisorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModeratorSupervisor");
        }
    }
}
