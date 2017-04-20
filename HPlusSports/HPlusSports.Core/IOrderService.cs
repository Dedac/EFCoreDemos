using System.Collections.Generic;
using System.Threading.Tasks;
using HPlusSports.Models;

namespace HPlusSports.Core
{
    public interface IOrderService
    {
        Task<IList<Order>> GetCustomerOrders(int CustomerId);
    }
}