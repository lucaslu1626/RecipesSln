﻿using System.ComponentModel.DataAnnotations.Schema;
namespace RecipesApp.Models
{
    public class Product
    {
        public long? RecipeID { get; set; }
        public string RecipeOrigin { get; set; } = String.Empty;
        public string RecipeName { get; set; } = String.Empty;
        public string RecipeCreator { get; set; } = String.Empty;
        [Column(TypeName = "decimal(3, 1)")]
        public decimal RecipeRating { get; set; }
        public string RecipeIngredients { get; set; } = String.Empty;
       
        public string RecipeInstructions { get; set; } = String.Empty;
    }
}
