using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HPlusSports.Core;
using HPlusSports.Web.ViewModels;

namespace HPlusSports.Web.Controllers
{
    public class OrderController : Controller
    {
        IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<ActionResult> Index()
        {
            var vm = new OrderListViewModel();
            vm.Orders = await _orderService.GetCustomerOrders(0);

            return View(vm);
        }

        public ActionResult Customer(int id)
        {
            return View();
        }

    }
}