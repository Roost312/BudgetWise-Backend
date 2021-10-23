using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetWise.Api.Migrations
{
    public partial class ConfiguredUserRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "Categories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_user_id",
                table: "Transactions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_user_id",
                table: "Categories",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_user_id",
                table: "Categories",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_user_id",
                table: "Transactions",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_user_id",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_user_id",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_user_id",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Categories_user_id",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Categories");
        }
    }
}
