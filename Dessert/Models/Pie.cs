using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dessert.Models
{
    public class Pie
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public string? AllergyInformation { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageThumbnailUrl { get; set; }
        public bool IsPieOfTheWeek { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; } = new Category();
    }
}