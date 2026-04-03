using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuizSystem.Models;
using QuizSystem.Data;

namespace QuizSystem.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        // ✅ FIX: add context + call base
        public HomeController(AppDbContext context, ILogger<HomeController> logger) 
            : base(context)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Optional: no user here, so no SetUser()
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel 
            { 
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
            });
        }
    }
}