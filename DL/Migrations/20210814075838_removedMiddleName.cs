using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class removedMiddleName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mname",
                table: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mname",
                table: "Customers",
                type: "text",
                nullable: true);
        }
    }
}
