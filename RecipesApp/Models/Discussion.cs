namespace RecipesApp.Models
{
    public class Discussion
    {
        public long? DiscussionID { get; set; }
        public long? DiscussionUser { get; set; } //discussion user type = user id?
        public string DiscussionPost { get; set; } = String.Empty;
        public string DiscussionDate { get; set; } = String.Empty;
    }
}