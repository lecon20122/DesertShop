using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dessert.Models;
using Dessert.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dessert.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IShoppingCart _shoppingCart;
        public ShoppingCartSummary(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();
            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());
            return View(shoppingCartViewModel);
        }
    }
}