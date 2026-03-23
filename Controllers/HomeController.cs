using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using VividPath.DTO;
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

    [HttpPost]
    public async Task<IActionResult> LogIn([FromBody] LogInDto loginDto)
    {

        // CALL THE USER TABLE HERE

        var claims = new List<Claim>
        {
            new Claim("Email", loginDto.Email)
        };

        var identity = new ClaimsIdentity(claims, "UserSession");
        var principal = new ClaimsPrincipal(identity); 

        await HttpContext.SignInAsync("UserSession", principal);
        return Ok( new { redirect = "/Home/Main", isLoggedIn = true});
    }
  
    [HttpPost]
    public async Task<IActionResult> LogOut()
    {
        await HttpContext.SignOutAsync("UserSession");
        return Ok();
    }
}
