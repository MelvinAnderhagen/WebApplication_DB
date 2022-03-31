using WebApplication3.Models;

namespace WebApplication3.Services
{
    public class FreightService : IFreightService
    {
        public bool HasFreeFreight(Order order)
        {
            return order.Customer.City.StartsWith("A");
        }
    }
}
