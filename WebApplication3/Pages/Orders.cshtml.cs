using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Models;

namespace WebApplication3.Pages
{
    public class OrdersModel : PageModel
    {
        private readonly NorthwindContext _context;
        public List<OrderViewModel> Orders { get; set; }

        public class OrderViewModel
        {
            public int Id { get; set; }
            public string DateTime { get; set; }
            public string CustomerName { get; set; }
        }
        public OrdersModel(NorthwindContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Orders = _context.Orders.Select(n => new OrderViewModel
            {
                CustomerName = n.Customer.CompanyName,
                Id = n.OrderId,
                DateTime = n.OrderDate.Value.ToString("yyyy-MM-dd")
            }).ToList();  
        }
    }
}
