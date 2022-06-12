using Microsoft.AspNetCore.Mvc;
using RecipesApp.Models;
using RecipesApp.Models.ViewModels;

namespace RecipesApp.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public int PageSize = 1;
        private StoreDbContext context;

        public HomeController(IStoreRepository repo, StoreDbContext dbContext)
        {
            repository = repo;
            context = dbContext;
        }

        public ActionResult ViewRecipe(string name, string creator, string ingredients, string instructions)
        {
            if (name == null) return View("Index");
            else
            {
                ViewBag.Name = name;
                ViewBag.creator = creator;
                ViewBag.ingredients = ingredients;
                ViewBag.instructions = instructions;
                return View("Recipe");
            }
        }

        public ViewResult Index(string? category, string? recipe, int recipePage = 10)
            => View(new RecipesListViewModel
            {
                Recipes = repository.Recipes
                    .Where(p => category == null || p.RecipeCategory == category)
                    .OrderBy(p => p.RecipeID)
                    .Skip((recipePage - 1) * PageSize)
                    .Take(PageSize),
                Discussions = repository.Discussions
                    .Where(p => recipe == null || p.DiscussionRecipe == recipe)
                    .OrderBy(p => p.DiscussionID),

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
/*
        [HttpPost]
        public IActionResult SubmitForm(RecipesListViewModel model)
        {
            model.Discussion.DiscussionDate = DateTime.Now.ToString("MM/dd/yy H:mm:ss");
            model.Discussion.DiscussionUser = "user1";
            model.Discussion.DiscussionRecipe = "Golden Apple Pie";
            try
            {
                Discussion discussion = new Discussion();

                discussion.DiscussionDate = model.Discussion.DiscussionDate;
                discussion.DiscussionPost = model.Discussion.DiscussionPost;
                discussion.DiscussionUser = model.Discussion.DiscussionUser;
                discussion.DiscussionRecipe = model.Discussion.DiscussionRecipe;
                context.Discussions.Add(new Discussion
                {
                    DiscussionDate = DateTime.Now.ToString("MM/dd/yy H:mm:ss"),
                    DiscussionPost = model.Discussion.DiscussionPost,
                    DiscussionRecipe = "Golden Apple Pie",
                    DiscussionUser = "user1"
                });
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return View("Index");
            //return RedirectToAction(nameof(Results));

        }

        public ActionResult Results()
        {
            return View("Index");
        }*/

    }
}
