using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DiscordKiller.Examples.AspNetCore.MVC.Models;

namespace DiscordKiller.Examples.AspNetCore.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var homeViewModel = new HomeViewModel() { Name = "Index Action in Home Controller" };
        return View(homeViewModel);
    }

    public IActionResult Privacy()
    {
        var homeViewModel = new HomeViewModel() { Name = "Privacy Action in Home Controller" };
        return View(homeViewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}