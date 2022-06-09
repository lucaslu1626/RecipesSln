using Microsoft.AspNetCore.Mvc;
using RecipesApp.Models;
using RecipesApp.Models.ViewModels;

namespace RecipesApp.Controllers
{
    public class DiscussionController : Controller
    {

        private StoreDbContext context;
        private IStoreRepository repository;

        public DiscussionController(StoreDbContext dbContext, IStoreRepository repository)
        {
            context = dbContext;
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View("DiscussionForm");
        }


        [HttpPost]
        public ActionResult SubmitForm(RecipesListViewModel model)
        {
            Discussion discussion = new Discussion
            {
                DiscussionDate = DateTime.Now.ToString("MM/dd/yy H:mm:ss"),
                DiscussionPost = model.Discussion.DiscussionPost,
                // Adjust DiscussionRecipe to adjust based on the page the discussion post is submitted
                DiscussionRecipe = "Black bean and corn Nachos",
                DiscussionUser = "user1"
            };
            repository.CreateDiscussion(discussion);
            context.SaveChanges();

            return RedirectToAction(nameof(Results));

        }

        public ActionResult Results()
        {
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
