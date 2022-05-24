using Microsoft.AspNetCore.Mvc;
using RecipesApp.Models;

namespace RecipesApp.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index() => View(repository.Recipes);
    }
}
