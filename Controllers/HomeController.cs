using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
//using VividPath.Models;

namespace VividPath.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Main()
    {
        return View();
    }

    public IActionResult LogIn()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    public IActionResult Profile()
    {
        return View();
    }

     public IActionResult Course()
    {
        return View();
    }

     public IActionResult Learn()
    {
        return View();
    }
  
}
