using System.ComponentModel.DataAnnotations;
/*using Microsoft.AspNetCore.Mvc.ModelBinding;*/
namespace RecipesApp.Models
{
    public class Discussion
    {
        public long? DiscussionID { get; set; }
        public string DiscussionUser { get; set; } = String.Empty;
        [Required(ErrorMessage = "Please enter your comment")]
        public string DiscussionPost { get; set; } = String.Empty;
        public string DiscussionDate { get; set; } = String.Empty;
        public string DiscussionRecipe { get; set; } = String.Empty;

        //public User? User { get; set; }
        public Recipe? Recipe { get; set; }
        

    }
}