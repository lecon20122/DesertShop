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
    // [Route("[controller]")]
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _pieRepository = pieRepository;
        }
        // [Route("[action]")]
        public IActionResult List(string category)
        {
            IEnumerable<Pie> pies;
            string? currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                currentCategory = "All pies";
                pies = _pieRepository.AllPies.OrderBy(p => p.Id);
            }
            else
            {
                currentCategory = _categoryRepository.GetAllCategories().FirstOrDefault(c => c.Name == category)?.Name;
                pies = _pieRepository.AllPies.Where(p => p.Category?.Name == currentCategory).OrderBy(p => p.Id);
            }
            PieListViewModel pieListViewModel = new PieListViewModel(pies, currentCategory!);
            return View(pieListViewModel);
        }
        // [Route("[action]/{id?}")]
        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie is null) return NotFound();
            return View(pie);
        }
    }
}