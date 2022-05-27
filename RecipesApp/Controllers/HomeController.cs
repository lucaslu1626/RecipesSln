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
        public ViewResult Index(int recipePage = 1)
            => View(new RecipesListViewModel
            {
                Recipes = repository.Recipes
                    .OrderBy(p => p.RecipeID)
                    .Skip((recipePage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo 
                {
                    CurrentPage = recipePage,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Recipes.Count() 
                }
            });
                
    }
}
