namespace RecipesApp.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        private StoreDbContext context;
        public EFStoreRepository(StoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Recipe> Recipes => context.Recipes;
        public IQueryable<Discussion> Discussions => context.Discussions;
        public IQueryable<User> Users => context.Users;

        public void CreateRecipe(Recipe p)
        {
            context.Recipes.Add(p);
            context.SaveChanges();
        }
        public void DeleteRecipe(Recipe p)
		{
            context.Recipes.Remove(p);
            context.SaveChanges();
		}
        public void SaveRecipe(Recipe p)
		{
            context.SaveChanges();
		}
        public void CreateDiscussion(Discussion s)
        {
            context.Discussions.Add(s);
            context.SaveChanges();
        }
        public void DeleteDiscussion(Discussion s)
		{
            context.Discussions.Remove(s);
            context.SaveChanges();
		}
        public void SaveDiscussion(Discussion s)
		{
            context.SaveChanges();
		}
    }
}
