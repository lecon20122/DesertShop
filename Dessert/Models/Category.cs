using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dessert.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public List<Pie>? Pies { get; set; }
    }
}