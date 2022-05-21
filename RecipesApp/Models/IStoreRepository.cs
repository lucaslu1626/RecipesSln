namespace RecipesApp.Models
{
    public interface IStoreRepository
    {
        IQueryable<Recipe> Recipes { get; }
        IQueryable<Discussion> Discussions { get; }
        IQueryable<User> Users { get; }
    }
}
