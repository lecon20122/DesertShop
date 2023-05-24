using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dessert.Models
{
    public class MockPieRepository : IPieRepository
    {

        public IEnumerable<Pie> AllPies =>
            new List<Pie>
            {
                new Pie {Id = 1  , Name = "Strawberry Pie", Price = 15.95M, ShortDescription = "Lorem Ipsum", LongDescription = "Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum ", ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypie.jpg", ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypiesmall.jpg", IsPieOfTheWeek = true, InStock = true, CategoryId = 1, Category = null},
                new Pie {Id = 2  , Name = "Cheese Cake", Price = 18.95M, ShortDescription = "Lorem Ipsum", LongDescription = "Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum ", ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecake.jpg", ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecakesmall.jpg", IsPieOfTheWeek = false, InStock = true, CategoryId = 2, Category = null},
                new Pie {Id = 3  , Name = "Rhubarb Pie", Price = 15.95M, ShortDescription = "Lorem Ipsum", LongDescription = "Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum ", ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/rhubarbpie.jpg", ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/rhubarbpiesmall.jpg", IsPieOfTheWeek = false, InStock = true, CategoryId = 3, Category = null},
                new Pie {Id = 4  , Name = "Pumpkin Pie", Price = 12.95M, ShortDescription = "Lorem Ipsum", LongDescription = "Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum ", ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/pumpkinpie.jpg", ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/pumpkinpiesmall.jpg", IsPieOfTheWeek = true, InStock = true, CategoryId = 2, Category = null},
                new Pie {Id = 5  , Name = "Apple Pie", Price = 15.95M, ShortDescription = "Lorem Ipsum", LongDescription = "Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum ", ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg", ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg", IsPieOfTheWeek = false, InStock = true, CategoryId = 1, Category = null},
            };

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return AllPies.Where(p => p.IsPieOfTheWeek);
            }
        }
        public Pie? GetPieById(int pieId) => AllPies.FirstOrDefault(p => p.Id == pieId);
    }
}