using HPlusSports.DAL;
using HPlusSports.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSports.Core
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepo;
        HPlusSportsContext _context;

        public OrderService(IOrderRepository orderRepo, HPlusSportsContext context)
        {
            _orderRepo = orderRepo;
            _context = context;
        }

        public async Task<IList<Order>> GetCustomerOrders(int CustomerId)
        {
            return await _context.Set<Order>()
                .AsNoTracking()
                .Include(o => o.Customer)
                .Where(o => o.CustomerId == CustomerId)
                .ToListAsync();
        }

        public async Task<IList<Order>> GetOrdersWithCustomers()
        {
            return await _context.Set<Order>()
                .AsNoTracking()
                .Include(o => o.Customer)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }

        public async Task<Order> CreateOrder(int customerId, int salesPersonId, List<Tuple<string, int>> productsQuantities)
        {
            var order = _orderRepo.Create(new NewOrderInformation()
            {
                CustomerId = customerId,
                SalesPersonId = salesPersonId,
                products = productsQuantities.Select(p =>
                {
                    return new ProductOrderInformation()
                    {
                        ProductCode = p.Item1,
                        Quantity = p.Item2,
                        Price = GetPriceWithDiscounts(p.Item1, p.Item2)
                    };
                }).ToList()
            });

            await _context.SaveChangesAsync();
            return order;
        }

        private decimal GetPriceWithDiscounts(string productCode, int quantity)
        {
            var product = _context.Set<Product>().First(p => p.ProductCode == productCode);
            if (product.Price > 10 && quantity > 100)
                return (product.Price ?? 1) * 0.95m;
            else
                return product.Price ?? 1;

        }

        public async Task UpdatePrice(int id, decimal newPrice)
        {
            var order = await _context.Order.FindAsync(id);
            order.TotalDue = newPrice;
            await _context.SaveChangesAsync();
        }

        public async Task<string> MarkPaid(int id, decimal amount)
        {
            var order = await _context.Order.FindAsync(id);
            //Since this is a web application we can set the original value 
            //we are paying for in entity framework, so that ef knows the value
            //is changed when saving
            _context.Entry(order).Property("TotalDue").OriginalValue = amount;

            try
            {
                order.Status = "Paid";
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //Handle concurrency programatically here if possible
                return "The price doesn't match the current price on the order, please try again.";
            }
            return ""; //Do something better that returning a non-empty string to indicate success
           
        }
    }
}
