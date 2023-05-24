using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dessert.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DessertDbContext _dbContext;
        private readonly IShoppingCart _shoppingCart;
        public OrderRepository(DessertDbContext dbContext, IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
            _dbContext = dbContext;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem> shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = item.Amount,
                    PieId = item.Pie.Id,
                    Price = item.Pie.Price
                };
                order.OrderDetails.Add(orderDetail);
            }
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }
    }
}