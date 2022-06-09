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
                DiscussionRecipe = model.CurrentRecipe,
                DiscussionUser = "user1"
            };
            repository.SaveDiscussion(discussion);
            context.SaveChanges();

            //return RedirectToAction("Index");
            return RedirectToAction(nameof(Results));

        }

        public ActionResult Results()
        {
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
