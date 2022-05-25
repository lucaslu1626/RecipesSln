using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserPW = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.UniqueConstraint("AK_Users_UserName", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeCreator = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecipeRating = table.Column<decimal>(type: "decimal(3,1)", nullable: false),
                    RecipeIngredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeInstructions = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeID);
                    table.UniqueConstraint("AK_Recipes_RecipeCreator", x => x.RecipeCreator);
                    table.ForeignKey(
                        name: "FK_Recipes_Users_RecipeCreator",
                        column: x => x.RecipeCreator,
                        principalTable: "Users",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discussions",
                columns: table => new
                {
                    DiscussionID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscussionUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscussionPost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscussionDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscussionRecipe = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discussions", x => x.DiscussionID);
                    table.ForeignKey(
                        name: "FK_Discussions_Recipes_DiscussionRecipe",
                        column: x => x.DiscussionRecipe,
                        principalTable: "Recipes",
                        principalColumn: "RecipeCreator",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discussions_DiscussionRecipe",
                table: "Discussions",
                column: "DiscussionRecipe");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discussions");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
