using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RecipesApp.Controllers;
using RecipesApp.Models;
using Xunit;

namespace RecipesApp.Tests
{
    public class RecipeTests
    {
        [Fact]
        public void ChangeRecipeDetails()
        {
            // Arrange
            var recipe = new Recipe();
            recipe.RecipeName = "Golden Apple Pie";
            recipe.RecipeCategory = "American";

            // Act
            recipe.RecipeName = "Pulled Pork Tacos";
            // Assert
            Assert.Equal("Pulled Pork Tacos", recipe.RecipeName);
            Assert.Equal("American", recipe.RecipeCategory);

        }
    }
}
