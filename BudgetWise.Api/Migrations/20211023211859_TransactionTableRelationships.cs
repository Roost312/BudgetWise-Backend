using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetWise.Api.Migrations
{
    public partial class TransactionTableRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "transaction_id",
                table: "Labels");

            migrationBuilder.AddColumn<int>(
                name: "label_id",
                table: "Transactions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_label_id",
                table: "Transactions",
                column: "label_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Labels_label_id",
                table: "Transactions",
                column: "label_id",
                principalTable: "Labels",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Labels_label_id",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_label_id",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "label_id",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "transaction_id",
                table: "Labels",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
