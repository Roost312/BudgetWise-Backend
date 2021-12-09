using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetWise.Api.Migrations
{
    public partial class RemoveSuperfluousTransactionProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "active",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "apply_to_daily",
                table: "Transactions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "active",
                table: "Transactions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "apply_to_daily",
                table: "Transactions",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
