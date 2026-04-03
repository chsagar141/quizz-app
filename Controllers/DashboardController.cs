using Microsoft.AspNetCore.Mvc;
using QuizSystem.Data;
using System.Linq;

namespace QuizSystem.Controllers
{
    public class DashboardController : BaseController
    {
        // ❌ REMOVE duplicate _context

        // ✅ FIX constructor
        public DashboardController(AppDbContext context) : base(context)
        {
        }

        public IActionResult Index(int userId)
        {
            SetUser(userId); // ✅ this sets Username + UserId

            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
                return Content("User not found");

            ViewBag.Role = user.Role;

            if (user.Role == "Teacher")
            {
                var quizzes = _context.Quizzes
                    .Where(q => q.CreatedBy == userId)
                    .ToList();

                ViewBag.Quizzes = quizzes;
            }

            return View();
        }
    }
}