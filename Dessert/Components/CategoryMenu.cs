using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dessert.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dessert.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.GetAllCategories();
            return View(categories);
        }
    }
}