using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dessert.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dessert.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
            _orderRepository = orderRepository;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();

            if (items.Count == 0) ModelState.AddModelError("", "Your cart is empty, add some desserts first");

            if (items.Count > 0 && ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order! Enjoy your desserts!";
            return View();
        }
    }
}