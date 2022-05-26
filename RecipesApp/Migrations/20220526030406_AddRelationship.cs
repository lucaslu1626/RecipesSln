using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesApp.Migrations
{
    public partial class AddRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RecipeID",
                table: "Discussions",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discussions_RecipeID",
                table: "Discussions",
                column: "RecipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Discussions_Recipes_RecipeID",
                table: "Discussions",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "RecipeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discussions_Recipes_RecipeID",
                table: "Discussions");

            migrationBuilder.DropIndex(
                name: "IX_Discussions_RecipeID",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "RecipeID",
                table: "Discussions");
        }
    }
}
