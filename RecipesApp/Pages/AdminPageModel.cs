using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
namespace RecipesApp.Pages
{
    [Authorize(Roles = "Admins")]
    public class AdminPageModel : PageModel
    {
    }
}