using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class addedMiddleName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mname",
                table: "Customers",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mname",
                table: "Customers");
        }
    }
}
