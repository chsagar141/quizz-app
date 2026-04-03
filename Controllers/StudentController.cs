using Microsoft.AspNetCore.Mvc;
using QuizSystem.Data;
using QuizSystem.Models;
using System.Linq;

namespace QuizSystem.Controllers
{
    public class StudentController : BaseController
    {
        // ❌ REMOVE duplicate _context

        // ✅ FIX constructor
        public StudentController(AppDbContext context) : base(context)
        {
        }

        // ✅ Show all quizzes
        public IActionResult Index(int userId)
        {
            SetUser(userId); // ✅ important

            var quizzes = _context.Quizzes.ToList();

            return View(quizzes);
        }

        // ✅ Start quiz
        public IActionResult Start(int quizId, int userId)
        {
            SetUser(userId); // ✅ important

            var questions = _context.Questions
                .Where(q => q.QuizId == quizId)
                .ToList();

            ViewBag.QuizId = quizId;

            return View(questions);
        }

        // ✅ Submit quiz
        [HttpPost]
        public IActionResult Submit(int quizId, int userId, List<int> answers)
        {
            SetUser(userId); // ✅ important

            var questions = _context.Questions
                .Where(q => q.QuizId == quizId)
                .ToList();

            int score = 0;

            for (int i = 0; i < questions.Count; i++)
            {
                if (answers[i] == questions[i].CorrectOption)
                    score++;
            }

            var attempt = new Attempt
            {
                QuizId = quizId,
                StudentId = userId,
                Score = score,
                AttemptDate = DateTime.Now // ✅ IMPORTANT FIX
            };

            _context.Attempts.Add(attempt);
            _context.SaveChanges();

            ViewBag.Score = score;
            ViewBag.Total = questions.Count;
            ViewBag.UserId = userId; // ✅ needed for navigation

            return View("Result");
        }
    }
}