using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication3.Pages
{
    public class myPageModel : PageModel
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public myPageModel()
        {
            
        }

        public void OnGet()
        {
            Age = 15;
            Name = "Håkan";
        }
    }
}
