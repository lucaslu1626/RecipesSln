namespace RecipesApp.Models.ViewModels
{
    public class RecipesListViewModel
    {
        public IEnumerable<Recipe> Recipes { get; set; } = Enumerable.Empty<Recipe>();
        public PagingInfo PagingInfo { get; set; } = new();
    }
}
