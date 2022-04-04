using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Pages
{
    public class OrdersModel : PageModel
    {
        public OrdersModel(NorthwindContext context)
        {
            _context = context;
        }
        private readonly NorthwindContext _context;
        public List<OrderViewModel> Orders { get; set; }
        //[BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public int PageNo { get; set; }
        public class OrderViewModel
        {
            public int Id { get; set; }
            public string DateTime { get; set; }
            public string CustomerName { get; set; }
        }
        

        public void OnGet(string searchString, int pageno=1, string col = "id", string order = "asc")
        { 
            PageNo = pageno;
            SearchString = searchString;
            var sort = _context.Orders.Include(n => n.Customer).AsQueryable();

            if (!string.IsNullOrEmpty(SearchString))
            {
                sort = sort.Where(ord => ord.Customer.CompanyName.ToLower().Contains(SearchString)
            || ord.Customer.ContactName.ToLower().Contains(SearchString));
            }
            

            if (col == "id")
            {
                if (order == "asc")
                    sort = sort.OrderBy(ord => ord.OrderId);
                else
                    sort = sort.OrderByDescending(ord => ord.OrderId);
                
            }
            else if (col == "customer")
            {
                if (order == "asc")
               
                    sort = sort.OrderBy(ord => ord.Customer.CompanyName);
               
                else
                
                    sort = sort.OrderByDescending(ord => ord.Customer.CompanyName);
                
            }
            else if(col == "datetime")
            {
                if (order == "asc")
                    sort = sort.OrderBy(ord => ord.OrderDate);
                else 
                    sort = sort.OrderByDescending(ord => ord.OrderDate);
            }

            int toSkip = (pageno - 1) * 20;

            sort = sort.Skip(toSkip).Take(20);

            Orders = sort.Select(n => new OrderViewModel
            {
                CustomerName = n.Customer.CompanyName,
                Id = n.OrderId,
                DateTime = n.OrderDate.Value.ToString("yyyy-MM-dd")
            }).ToList();

        }
    }
}
