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
    }
}
