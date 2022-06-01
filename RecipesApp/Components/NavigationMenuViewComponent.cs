using Microsoft.AspNetCore.Mvc;
using RecipesApp.Models;

namespace RecipesApp.Components
{
	public class NavigationMenuViewComponent : ViewComponent 
	{
		private IStoreRepository repository;
		public NavigationMenuViewComponent(IStoreRepository repo)
		{
			repository = repo;
		}
		public IViewComponentResult Invoke()
		{
			ViewBag.SelectedCategory = RouteData?.Values["category"];
			return View(repository.Recipes
			.Select(x => x.RecipeCategory)
			.Distinct()
			.OrderBy(x => x));
		}
	}
}
