using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dessert.Models;

namespace Dessert.ViewModels
{
    public class PieListViewModel
    {
        public PieListViewModel(IEnumerable<Pie> pies, string currentCategory)
        {
            Pies = pies;
            CurrentCategory = currentCategory;
        }

        public IEnumerable<Pie> Pies { get; set; }

        public string CurrentCategory { get; set; }
    }
}