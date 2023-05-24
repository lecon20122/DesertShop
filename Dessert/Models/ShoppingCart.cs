using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dessert.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly DessertDbContext _context;
        public string? ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;
        public ShoppingCart(DessertDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            DessertDbContext context = services.GetService<DessertDbContext>() ?? throw new Exception("DB Context not found");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Pie pie)
        {
            var shoppingCartItem =
                    _context.ShoppingCartItems.SingleOrDefault(
                        s => s.Pie.Id == pie.Id && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Pie = pie,
                    Amount = 1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public void ClearCart()
        {
            var shoppingCartItems = _context.ShoppingCartItems
                    .Where(s => s.ShoppingCartId == ShoppingCartId)
                    ?? throw new Exception("Items not found");
            _context.ShoppingCartItems.RemoveRange(shoppingCartItems);
            _context.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??=
            _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Include(s => s.Pie)
                .ToList();
        }

        public decimal GetShoppingCartTotal()
        {
            return _context.ShoppingCartItems
                    .Where(s => s.ShoppingCartId == ShoppingCartId)
                    ?.Select(s => s.Pie.Price * s.Amount).Sum()
                    ?? throw new Exception("Item not found");
        }

        public int RemoveFromCart(Pie pie)
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault
            (
                s => s.Pie.Id == pie.Id
                && s.ShoppingCartId == ShoppingCartId
            ) ?? throw new Exception("Item not found");

            var localAmount = 0;

            if (shoppingCartItem.Amount > 1)
            {
                shoppingCartItem.Amount--;
                localAmount = shoppingCartItem.Amount;
            }
            else
            {
                _context.ShoppingCartItems.Remove(shoppingCartItem);
            }

            _context.SaveChanges();

            return localAmount;
        }
    }
}