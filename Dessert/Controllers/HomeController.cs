using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dessert.Models;
using Dessert.ViewModels;

namespace Dessert.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPieRepository _pieRepository;

    public HomeController(ILogger<HomeController> logger, IPieRepository pieRepository)
    {
        _pieRepository = pieRepository;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var piesOfTheWeek = _pieRepository.PiesOfTheWeek;
        return View(new HomeViewModel(piesOfTheWeek));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
