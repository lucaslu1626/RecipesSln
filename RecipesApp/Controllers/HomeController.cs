using Microsoft.AspNetCore.Mvc;
using RecipesApp.Models;
using RecipesApp.Models.ViewModels;

namespace RecipesApp.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public int PageSize = 1;
        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index(string? category, string? recipe, int recipePage = 1)
            => View(new RecipesListViewModel
            {
                Recipes = repository.Recipes
                    .Where(p => category == null || p.RecipeCategory == category)
                    .OrderBy(p => p.RecipeID)
                    .Skip((recipePage - 1) * PageSize)
                    .Take(PageSize),
                Discussions = repository.Discussions
                    .Where(p => category == null || p.DiscussionRecipe == recipe)
                    .OrderBy(p => p.DiscussionID),
                    /*.Skip((recipePage - 1) * PageSize)
                    .Take(PageSize),*/

                PagingInfo = new PagingInfo
                {
                    CurrentPage = recipePage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null
                        ? repository.Recipes.Count()
                        : repository.Recipes.Where(e =>
                        e.RecipeCategory == category).Count()
                },
                CurrentCategory = category,
                CurrentRecipe = recipe
            });
                
    }
}
