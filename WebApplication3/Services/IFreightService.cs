using WebApplication3.Models;

namespace WebApplication3.Services
{
    public interface IFreightService
    {
        bool HasFreeFreight(Order order);
    }
}
