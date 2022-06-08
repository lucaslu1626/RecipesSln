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

        /* [HttpPost]
         public ActionResult SubmitForm(string user, string post, string date, string recipe)
         {

             if (user == null || post == null || date == null || recipe == null)
             {
                 return View();
             }
             TempData["user param"] = user;
             TempData["post param"] = post;
             TempData["date param"] = date;
             TempData["recipe param"] = recipe;
             context.Discussions.Add(new Discussion
             {
                 DiscussionUser = user,
                 DiscussionPost = post,
                 DiscussionDate = date,
                 DiscussionRecipe = recipe
             });
             context.SaveChanges();
             return RedirectToAction(nameof(Results));
         }

         public IActionResult Results()
         {
             return View();
         }*/

       /* private IStoreRepository repository;
        //private StoreDbContext context;

        public DiscussionController(IStoreRepository repo)
        {
            repository = repo;
        }*/

      /*  public ActionResult Index()
        {
            return View("Index");
        }*/


        [HttpPost]
        public ActionResult SubmitForm(RecipesListViewModel model)
        {
            /*string user, string post, string date, string recipe
             * if (user == null || post == null || date == null || recipe == null)
            {
                return View();
            }
            TempData["user param"] = user;
            TempData["post param"] = post;
            TempData["date param"] = date;
            TempData["recipe param"] = recipe;
            context.Discussions.Add(new Discussion
            {
                DiscussionUser = user,
                DiscussionPost = post,
                DiscussionDate = date,
                DiscussionRecipe = recipe
            });
            context.SaveChanges();
            return RedirectToAction(nameof(Results));*/
            Discussion discussion = new Discussion
            {
                DiscussionDate = DateTime.Now.ToString("MM/dd/yy H:mm:ss"),
                DiscussionPost = model.Discussion.DiscussionPost,
                DiscussionRecipe = "Golden Apple Pie",
                DiscussionUser = "user1"
            };
            repository.CreateDiscussion(discussion);
            context.Discussions.Add(new Discussion
            {
                DiscussionDate = DateTime.Now.ToString("MM/dd/yy H:mm:ss"),
                DiscussionPost = model.Discussion.DiscussionPost,
                DiscussionRecipe = "Golden Apple Pie",
                DiscussionUser = "user1"
            });
            context.SaveChanges();

            //return RedirectToAction("Index");
            return RedirectToAction(nameof(Results));

        }

        public ActionResult Results()
        {
            return View();
        }
    }
}
