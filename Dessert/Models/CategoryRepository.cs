using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dessert.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DessertDbContext _dbContext;

        public CategoryRepository(DessertDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _dbContext.Categories.OrderBy(c => c.Name);
        }
    }
}