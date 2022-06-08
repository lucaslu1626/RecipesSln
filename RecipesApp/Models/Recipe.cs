using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace RecipesApp.Models
{
    public class Recipe
    {
        public long? RecipeID { get; set; }
        [Required(ErrorMessage = "Please specify a category")]
        public string RecipeCategory { get; set; } = String.Empty;
        [Required(ErrorMessage = "Please enter a recipe name")]
        public string RecipeName { get; set; } = String.Empty;
        [Required(ErrorMessage = "Please enter your user name")]
        public string RecipeCreator { get; set; } = String.Empty;
        [Column(TypeName = "decimal(3, 1)")]
        public decimal RecipeRating { get; set; }
        [Required(ErrorMessage = "Please enter the ingredients of your recipe")]
        public string RecipeIngredients { get; set; } = String.Empty;
        [Required(ErrorMessage = "Please enter the instructions of your recipe")]
        public string RecipeInstructions { get; set; } = String.Empty;
        public User? User { get; set; }
        public List<Discussion>? Discussions { get; set; }
    }
}
