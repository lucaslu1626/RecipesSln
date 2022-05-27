using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesApp.Migrations
{
    public partial class RefineRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discussions_Recipes_RecipeID",
                table: "Discussions");

            migrationBuilder.DropForeignKey(
                name: "FK_Discussions_Users_DiscussionUser",
                table: "Discussions");

            migrationBuilder.DropIndex(
                name: "IX_Discussions_DiscussionUser",
                table: "Discussions");

            migrationBuilder.DropIndex(
                name: "IX_Discussions_RecipeID",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "RecipeID",
                table: "Discussions");

            migrationBuilder.AlterColumn<string>(
                name: "RecipeName",
                table: "Recipes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DiscussionUser",
                table: "Discussions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "DiscussionRecipe",
                table: "Discussions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Recipes_RecipeName",
                table: "Recipes",
                column: "RecipeName");

            migrationBuilder.CreateIndex(
                name: "IX_Discussions_DiscussionRecipe",
                table: "Discussions",
                column: "DiscussionRecipe");

            migrationBuilder.AddForeignKey(
                name: "FK_Discussions_Recipes_DiscussionRecipe",
                table: "Discussions",
                column: "DiscussionRecipe",
                principalTable: "Recipes",
                principalColumn: "RecipeName",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discussions_Recipes_DiscussionRecipe",
                table: "Discussions");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Recipes_RecipeName",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Discussions_DiscussionRecipe",
                table: "Discussions");

            migrationBuilder.AlterColumn<string>(
                name: "RecipeName",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "DiscussionUser",
                table: "Discussions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DiscussionRecipe",
                table: "Discussions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<long>(
                name: "RecipeID",
                table: "Discussions",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discussions_DiscussionUser",
                table: "Discussions",
                column: "DiscussionUser");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Discussions_Users_DiscussionUser",
                table: "Discussions",
                column: "DiscussionUser",
                principalTable: "Users",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
