namespace RecipesApp.Models
{
    public interface IStoreRepository
    {
        IQueryable<Recipe> Recipes { get; }
        IQueryable<Discussion> Discussions { get; }
        IQueryable<User> Users { get; }

        void CreateRecipe(Recipe p);
        void DeleteRecipe(Recipe p);
        void SaveRecipe(Recipe p);
        void CreateDiscussion(Discussion s);
        void DeleteDiscussion(Discussion s);
        void SaveDiscussion(Discussion s);
    }
}
