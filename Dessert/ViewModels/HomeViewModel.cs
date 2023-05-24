using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dessert.Models;

namespace Dessert.ViewModels
{
    public class HomeViewModel
    {
        public readonly IEnumerable<Pie> PiesOfTheWeek;
        public HomeViewModel(IEnumerable<Pie> piesOfTheWeek)
        {
            PiesOfTheWeek = piesOfTheWeek;
        }
    }
}