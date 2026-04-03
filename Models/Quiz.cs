using System.Collections.Generic;

namespace QuizSystem.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int CreatedBy { get; set; }

        public bool IsActive { get; set; } = true; // ✅ MUST be inside class

        public List<Question> Questions { get; set; } = new List<Question>();
    }
}