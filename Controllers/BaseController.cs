using Microsoft.AspNetCore.Mvc;
using QuizSystem.Data;
using System.Linq;

namespace QuizSystem.Controllers
{
    public class BaseController : Controller
    {
        protected readonly AppDbContext _context;

        public BaseController(AppDbContext context)
        {
            _context = context;
        }

        protected void SetUser(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                ViewBag.Username = user.Username;
                ViewBag.UserId = user.Id;
            }
        }
    }
}