using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetWise.Api.Migrations
{
    public partial class UpdateLabelIDToBeNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Labels_label_id",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "label_id",
                table: "Transactions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Labels_label_id",
                table: "Transactions",
                column: "label_id",
                principalTable: "Labels",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Labels_label_id",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "label_id",
                table: "Transactions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Labels_label_id",
                table: "Transactions",
                column: "label_id",
                principalTable: "Labels",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
