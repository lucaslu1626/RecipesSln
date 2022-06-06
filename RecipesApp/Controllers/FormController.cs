using Microsoft.AspNetCore.Mvc;
using RecipesApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RecipesApp.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class FormController : Controller
    {
        private StoreDbContext context;

        public FormController(StoreDbContext dbContext)
        {
            context = dbContext;
        }

		public ActionResult Index()
		{
			return View("Form");
		}

		[HttpPost]
        public IActionResult SubmitForm(string name, string category, string creator, string ingredients, string instructions)
        {
            if(name == null || category == null || creator == null || ingredients == null || instructions == null)
            {
                return View("Form");
            }
            TempData["name param"] = name;
            TempData["category param"] = category;
            TempData["creator param"] = creator;
            TempData["ingredients param"] = ingredients;
            TempData["instructions param"] = instructions;
            context.Recipes.Add(new Recipe
            {
                RecipeName = name,
                RecipeCategory = category,
                RecipeCreator = creator,
                RecipeIngredients = ingredients,
                RecipeInstructions = instructions
            });
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
                TempData["error"] = "Invalid Data entered.";
                return View("Form");
            }
            return RedirectToAction(nameof(Results));
        }

        public IActionResult Results()
        {
            return View();
        }
    }
}
