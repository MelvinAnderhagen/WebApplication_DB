using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Models;

namespace WebApplication3.Pages
{
    public class ShowArticleModel : PageModel
    {
        private readonly IKrisInfoService _context;

        public ShowArticleModel(IKrisInfoService context)
        {
            _context = context;
        }
        public string Title { get; set; }
        public string Text { get; set; }
        public string LinkURL { get; set; }
        public void OnGet(string ArticleId)
        {
            var article = _context.GetKrisInformation(ArticleId);

            Title = article.Title;
            Text = article.Text;
            LinkURL = article.LinkUrl;
        }
    }
}
