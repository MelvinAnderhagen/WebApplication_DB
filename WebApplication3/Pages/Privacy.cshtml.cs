using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication3.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public List<HockeyPlayersViewModel> Players { get; set; } = new List<HockeyPlayersViewModel>();

        public class HockeyPlayersViewModel
        {
            public int Id { get; set; }
            public string Namn { get; set; }
            public int Jersey { get; set; }
        }

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            int e = 12;

            Players.Add(new HockeyPlayersViewModel{
                Namn = "Stefan",
                Id = 1, 
                Jersey = 27
            });
            Players.Add(new HockeyPlayersViewModel
            {
                Namn = "Maxen max",
                Id = 2,
                Jersey = 67
            });
        }
    }
}