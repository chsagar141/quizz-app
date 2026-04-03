using Microsoft.AspNetCore.Mvc;
using QuizSystem.Data;
using QuizSystem.Models;
using System.Linq;

namespace QuizSystem.Controllers
{
    public class TeacherController : BaseController
    {
        // ❌ REMOVE duplicate _context

        // ✅ FIX constructor
        public TeacherController(AppDbContext context) : base(context)
        {
        }

        // ✅ View Questions
        public IActionResult ViewQuestions(int quizId, int userId)
        {
            SetUser(userId); // ✅ navbar fix

            var questions = _context.Questions
                .Where(q => q.QuizId == quizId)
                .ToList();

            ViewBag.QuizId = quizId;

            if (questions.Count == 0)
                ViewBag.Message = "No questions found";

            return View(questions);
        }

        // ✅ Edit Question (GET)
        public IActionResult EditQuestion(int id, int userId)
        {
            SetUser(userId);

            var question = _context.Questions.FirstOrDefault(q => q.Id == id);

            if (question == null)
                return Content("Question not found");

            return View(question);
        }

        // ✅ Edit Question (POST)
        [HttpPost]
        public IActionResult EditQuestion(Question updated, int userId)
        {
            SetUser(userId);

            var question = _context.Questions.FirstOrDefault(q => q.Id == updated.Id);

            if (question != null)
            {
                question.Text = updated.Text;
                question.Option1 = updated.Option1;
                question.Option2 = updated.Option2;
                question.Option3 = updated.Option3;
                question.Option4 = updated.Option4;
                question.CorrectOption = updated.CorrectOption;

                _context.SaveChanges();
            }

            return RedirectToAction("ViewQuestions", new 
            { 
                quizId = updated.QuizId, 
                userId = userId 
            });
        }

        // ✅ Create Quiz (GET)
        public IActionResult CreateQuiz(int userId)
        {
            SetUser(userId);

            return View();
        }

        // ✅ Create Quiz (POST)
        [HttpPost]
        public IActionResult CreateQuiz(string title, int userId)
        {
            SetUser(userId);

            var quiz = new Quiz
            {
                Title = title,
                CreatedBy = userId
            };

            _context.Quizzes.Add(quiz);
            _context.SaveChanges();

            return RedirectToAction("AddQuestion", new 
            { 
                quizId = quiz.Id, 
                userId = userId 
            });
        }

        // ✅ Add Question (GET)
        public IActionResult AddQuestion(int quizId, int userId)
        {
            SetUser(userId);

            var quiz = _context.Quizzes.FirstOrDefault(q => q.Id == quizId);

            if (quiz == null)
                return Content("Quiz not found");

            ViewBag.QuizId = quizId;

            return View();
        }

        // ✅ Add Question (POST)
        [HttpPost]
        public IActionResult AddQuestion(int quizId, int userId, string text,
            string option1, string option2, string option3, string option4,
            int correctOption)
        {
            SetUser(userId);

            var question = new Question
            {
                QuizId = quizId,
                Text = text,
                Option1 = option1,
                Option2 = option2,
                Option3 = option3,
                Option4 = option4,
                CorrectOption = correctOption
            };

            _context.Questions.Add(question);
            _context.SaveChanges();

            TempData["Message"] = "Question Added!";

            return RedirectToAction("AddQuestion", new 
            { 
                quizId = quizId, 
                userId = userId 
            });
        }

        // ✅ Delete Question
        public IActionResult DeleteQuestion(int id, int userId)
        {
            SetUser(userId);

            var q = _context.Questions.FirstOrDefault(x => x.Id == id);

            if (q != null)
            {
                int quizId = q.QuizId;

                _context.Questions.Remove(q);
                _context.SaveChanges();

                return RedirectToAction("ViewQuestions", new 
                { 
                    quizId = quizId, 
                    userId = userId 
                });
            }

            return Content("Question not found");
        }
    }
}