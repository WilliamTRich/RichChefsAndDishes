using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RichChefsAndDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace RichChefsAndDishes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.AllChefs = _context.Chefs.Include(e => e.CreatedDishes).ToList();
        return View();
    }

    public IActionResult Dishes()
    {
        ViewBag.AllDishes = _context.Dishes.Include(a => a.Chef).ToList();
        return View("Dishes");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    //CREATE
    [HttpGet("chefs/new")]
    public IActionResult NewChef()
    {
        return View("NewChef");
    }
    [HttpPost("chef/create")]
    public IActionResult CreateChef(Chef newChef)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("NewChef");
        }
    }
    [HttpGet("dishes/new")]
    public IActionResult NewDish()
    {
        ViewBag.AllChefs = _context.Chefs.ToList();
        return View("NewDish");
    }
    [HttpPost("dish/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Dishes");
        }
        else return View("NewDish");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
