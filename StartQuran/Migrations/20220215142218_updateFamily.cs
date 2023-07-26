using Microsoft.EntityFrameworkCore.Migrations;

namespace StartQuran.Migrations
{
    public partial class updateFamily : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SupervisorId",
                table: "Families",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Families_SupervisorId",
                table: "Families",
                column: "SupervisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Families_AspNetUsers_SupervisorId",
                table: "Families",
                column: "SupervisorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Families_AspNetUsers_SupervisorId",
                table: "Families");

            migrationBuilder.DropIndex(
                name: "IX_Families_SupervisorId",
                table: "Families");

            migrationBuilder.DropColumn(
                name: "SupervisorId",
                table: "Families");
        }
    }
}
