namespace RecipesApp.Models
{
    public class Discussion
    {
        public long? DiscussionID { get; set; }
        public string DiscussionUser { get; set; } = String.Empty; //discussion user type = user id?
        public string DiscussionPost { get; set; } = String.Empty;
        public string DiscussionDate { get; set; } = String.Empty;
    }
}