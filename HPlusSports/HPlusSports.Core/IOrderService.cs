﻿using System.Collections.Generic;
using System.Threading.Tasks;
using HPlusSports.Models;
using System;

namespace HPlusSports.Core
{
    public interface IOrderService
    {
        Task<IList<Order>> GetCustomerOrders(int CustomerId);
        Task<Order> CreateOrder(int customerId, int salesPersonId, List<Tuple<string, int>> productsQuantities);
    }
}