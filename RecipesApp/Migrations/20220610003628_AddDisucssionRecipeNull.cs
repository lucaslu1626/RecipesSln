using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesApp.Migrations
{
    public partial class AddDisucssionRecipeNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discussions_Recipes_DiscussionRecipe",
                table: "Discussions");

            migrationBuilder.AlterColumn<string>(
                name: "DiscussionRecipe",
                table: "Discussions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Discussions_Recipes_DiscussionRecipe",
                table: "Discussions",
                column: "DiscussionRecipe",
                principalTable: "Recipes",
                principalColumn: "RecipeName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discussions_Recipes_DiscussionRecipe",
                table: "Discussions");

            migrationBuilder.AlterColumn<string>(
                name: "DiscussionRecipe",
                table: "Discussions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Discussions_Recipes_DiscussionRecipe",
                table: "Discussions",
                column: "DiscussionRecipe",
                principalTable: "Recipes",
                principalColumn: "RecipeName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
