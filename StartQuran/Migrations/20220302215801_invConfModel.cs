using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StartQuran.Migrations
{
    public partial class invConfModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceConfirmation",
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
                    InvoiceDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceConfirmation", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceConfirmation");
        }
    }
}
