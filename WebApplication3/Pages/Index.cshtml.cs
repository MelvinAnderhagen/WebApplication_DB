using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Models;

namespace WebApplication3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ILotteryService _context;
        public string Winningnumber { get; set; }
        public IndexModel(ILogger<IndexModel> logger, ILotteryService context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            Winningnumber = _context.GetWinningNumber();
        }
    }
}