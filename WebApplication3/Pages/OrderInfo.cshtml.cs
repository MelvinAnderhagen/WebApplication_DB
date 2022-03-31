using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Pages
{
    public class OrderInfoModel : PageModel
    {
        private readonly NorthwindContext _context;
        private readonly IFreightService _freightservice;

        public OrderInfoModel(NorthwindContext context, IFreightService freightservice)
        {
            _context = context;
            _freightservice = freightservice;
        }
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string DateTime { get; set; }
        public string ContactName { get; set; }
        public bool HasFreeFreight { get; set; }

        public List<OrderDetailViewModel> OrderRows { get; set; }

        public class OrderDetailViewModel
        {
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal RowPrice()
            {
                return Quantity * UnitPrice;
            }
        }
        
        public void OnGet(int id)
        {
            var order = _context.Orders.Include(n => n.Customer).Include(n => n.OrderDetails).ThenInclude(n => n.Product)
                .First(n => n.OrderId == id);

            Id = order.OrderId;
            CustomerName = order.Customer.CompanyName;
            ContactName = order.Customer.ContactName;
            DateTime = order.OrderDate.Value.ToString("yyyy-MM-dd");
            HasFreeFreight = _freightservice.HasFreeFreight(order);

            OrderRows = order.OrderDetails.Select(n => new OrderDetailViewModel
            {
                ProductName = n.Product.ProductName,
                Quantity = n.Quantity,
                UnitPrice = n.UnitPrice
            }).ToList();
        }
    }
}
