using Microsoft.EntityFrameworkCore;
namespace RecipesApp.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
        : base(options) { }
        public DbSet<Recipe> Recipes => Set<Recipe>();
        public DbSet<Discussion> Discussions => Set<Discussion>();
        public DbSet<User> Users => Set<User>();
    }
}
