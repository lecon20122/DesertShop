using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dessert.Models;
using Dessert.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dessert.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly IPieRepository _pieRepository;
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IPieRepository pieRepository, IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
            _pieRepository = pieRepository;

        }

        public ViewResult Index()
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();
            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());
            return View(shoppingCartViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]


        public RedirectToActionResult AddToShoppingCart(int pieId)
        {
            var selectedPie = _pieRepository.AllPies.FirstOrDefault(p => p.Id == pieId);

            if (selectedPie is not null)
            {
                _shoppingCart.AddToCart(selectedPie);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int pieId)
        {
            var selectedPie = _pieRepository.AllPies.FirstOrDefault(p => p.Id == pieId);

            if (selectedPie is not null)
            {
                _shoppingCart.RemoveFromCart(selectedPie);
            }

            return RedirectToAction("Index");
        }
    }
}