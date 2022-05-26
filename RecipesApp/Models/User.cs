namespace RecipesApp.Models
{
    public class User
    {
        public long UserID { get; set; }
        public string UserPW { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public List<Recipe>? Recipes { get; set; }
        public List<Discussion>? Discussions { get; set; }


    }
}
