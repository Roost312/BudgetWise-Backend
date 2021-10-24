using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetWise.Api.Migrations
{
    public partial class AddNamePropertyToLabels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Labels",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "Labels");
        }
    }
}
