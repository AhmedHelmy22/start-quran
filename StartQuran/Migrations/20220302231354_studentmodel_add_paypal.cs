using Microsoft.EntityFrameworkCore.Migrations;

namespace StartQuran.Migrations
{
    public partial class studentmodel_add_paypal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailZoom",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PasswordZoom",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "Paypal",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paypal",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "EmailZoom",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordZoom",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
