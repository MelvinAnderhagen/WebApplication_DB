using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication3.Pages
{
    public class RandomModel : PageModel
    {

        public int Number { get; set; }
        public string Meddelande { get; set; }
        public string Time { get; set; }
        public void OnGet()
        {
            Random rnd  = new Random();

            Number = rnd.Next(0,300000);

            Time = DateTime.Now.ToString("HH:mm");

            if(Number > 200000)
            {
                Meddelande = "Stort nummer";
            }else if(Number > 100000)
            {
                Meddelande = "Ganska stort nummer";
            }
            else
            {
                Meddelande = "Litet nummer";
            }
        }
    }
}
