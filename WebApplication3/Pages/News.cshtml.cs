using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Models;

namespace WebApplication3.Pages
{
    public class NewsModel : PageModel
    {
        public List<newslistitem> Items { get; set; }

        private readonly IKrisInfoService _krisInfoService;

        public NewsModel(IKrisInfoService krisInfoService)
        {
            _krisInfoService = krisInfoService;
        }

        public class newslistitem
        {
            public string Id { get; set; }
            public string Title { get; set; }
            
        }
        public void OnGet()
        {
            Items = _krisInfoService.GetAllKrisInformation().Select(r => new newslistitem
            {
                Id = r.Id, 
                Title = r.Title
            }).ToList();
        }
    }
}
