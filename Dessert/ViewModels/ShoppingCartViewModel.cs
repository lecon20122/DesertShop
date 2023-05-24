using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dessert.Models;

namespace Dessert.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel(IShoppingCart shoppingCart, decimal shoppingCartTotal)
        {
            ShoppingCartTotal = shoppingCartTotal;
            ShoppingCart = shoppingCart;
        }
        public IShoppingCart ShoppingCart;
        public decimal ShoppingCartTotal { get; }
    }
}