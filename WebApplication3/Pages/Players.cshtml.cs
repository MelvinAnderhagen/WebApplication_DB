using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication3.Pages
{
    public class PlayersModel : PageModel
    {

        public List<string> players = new List<string>();
        public void OnGet()
        {
            players.Add("Kalle");
            players.Add("Stefan");
        }
    }
}
