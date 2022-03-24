using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Models;

namespace WebApplication3.Pages
{
    public class SuppliersModel : PageModel
    {
        public SuppliersModel(NorthwindContext context)
        {
            _context = context;
        }
        public class SupplierViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string City { get; set; }
        }
        public List<SupplierViewModel> Suppliers = new List<SupplierViewModel>();
        private readonly NorthwindContext _context;

        public string CurrentWeekDay { get; set; }
        public void OnGet()
        {
            CurrentWeekDay = DateTime.Now.DayOfWeek.ToString();

            var culture = new System.Globalization.CultureInfo("sv-SE");
            var day = culture.DateTimeFormat.GetDayName(DateTime.Today.DayOfWeek);

            CurrentWeekDay = day;

            //Bättre sätt att göra på med SOLID dependency injection
            Suppliers = _context.Suppliers.Select(s => new SupplierViewModel
            {
                Name = s.CompanyName,
                City = s.City,
                Id = s.SupplierId
            }).ToList();

            //Dåligt sätt att göra saker på man vill inte newa upp saker
            //using (var context = new NorthwindContext())
            //{
            //    Suppliers = context.Suppliers.Select(s => s.CompanyName).ToList();
            //}
        }
    }
}
