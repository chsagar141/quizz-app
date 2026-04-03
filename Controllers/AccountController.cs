using Microsoft.AspNetCore.Mvc;
using QuizSystem.Data;
using QuizSystem.Models;
using System.Linq;

namespace QuizSystem.Controllers
{
    public class AccountController : BaseController
    {
        // ❌ REMOVE this:
        // private readonly AppDbContext _context;

        // ✅ FIX constructor
        public AccountController(AppDbContext context) : base(context)
        {
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                ViewBag.Error = "Invalid credentials";
                return View();
            }

            return RedirectToAction("Index", "Dashboard", new { userId = user.Id });
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}