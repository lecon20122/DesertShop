using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dessert.Models
{
    public class DessertDbContext : DbContext
    {
        public DessertDbContext(DbContextOptions<DessertDbContext> options) : base(options)
        {
        }

        public DbSet<Pie> Pies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}