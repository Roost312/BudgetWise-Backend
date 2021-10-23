using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetWise.Api.Migrations
{
    public partial class AddForeignKeyFromCategoriesToLabels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Labels_category_id",
                table: "Labels",
                column: "category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Labels_Categories_category_id",
                table: "Labels",
                column: "category_id",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labels_Categories_category_id",
                table: "Labels");

            migrationBuilder.DropIndex(
                name: "IX_Labels_category_id",
                table: "Labels");
        }
    }
}
