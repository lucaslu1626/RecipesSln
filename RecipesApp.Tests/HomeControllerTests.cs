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
    public class HomeControllerTests
    {
        [Fact]
        public void Can_Use_Repository()
        {
            // Arrange
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Recipes).Returns((new Recipe[] {
                new Recipe {RecipeID = 1, RecipeName = "P1"},
                new Recipe {RecipeID = 2, RecipeName = "P2"}
            }).AsQueryable<Recipe>());
            HomeController controller = new HomeController(mock.Object);
            // Act
            IEnumerable<Recipe>? result =
            (controller.Index() as ViewResult)?.ViewData.Model
            as IEnumerable<Recipe>;
            // Assert
            Recipe[] prodArray = result?.ToArray()
            ?? Array.Empty<Recipe>();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P1", prodArray[0].RecipeName);
            Assert.Equal("P2", prodArray[1].RecipeName);
        }
    }
}
