using HPlusSports.DAL;
using HPlusSports.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HPlusSports.Core
{
    public class OrderService : IOrderService
    {
        IRepository<Order> _orderRepo;
        public OrderService(IRepository<Order> orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<IList<Order>>  GetCustomerOrders(int CustomerId)
        {
            return await _orderRepo.Get(o => o.CustomerId == CustomerId, o => o.OrderDate);
        }
    }
}
