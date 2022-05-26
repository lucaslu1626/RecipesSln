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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                .HasOne(p => p.User)
                .WithMany(b => b.Recipes)
                .HasForeignKey(p => p.RecipeCreator)
                .HasPrincipalKey(b => b.UserName);

            modelBuilder.Entity<Discussion>()
                .HasOne(p => p.User)
                .WithMany(b => b.Discussions)
                .HasForeignKey(p => p.DiscussionUser)
                .HasPrincipalKey(b => b.UserName);
            //modelBuilder.Entity<Discussion>()
            //    .HasOne(p => p.Recipe)
            //    .WithMany(b => b.Discussions)
            //    .HasForeignKey(p => p.DiscussionRecipe)
            //    .HasPrincipalKey(b => b.RecipeCreator);
        }
    }
}
