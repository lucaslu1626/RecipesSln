using Microsoft.AspNetCore.Mvc;
using RecipesApp.Models;

namespace RecipesApp.Controllers
{
    public class FormController : Controller
    {
        private StoreDbContext context;

        public FormController(StoreDbContext dbContext)
        {
            context = dbContext;
        }

        public async Task<ActionResult> Index(long id = 1)
        {
            return View("Form", await context.Recipes.FindAsync(id));
        }

        [HttpPost]
        public IActionResult SubmitForm()
        {
            foreach (string key in Request.Form.Keys
                .Where(key => !key.StartsWith("_"))) {
                TempData[key] = string.Join(", ", Request.Form[key]);
            }
            return RedirectToAction(nameof(Results));
        }

        public IActionResult Results()
        {
            return View();
        }
    }
}
