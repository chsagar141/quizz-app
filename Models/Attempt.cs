namespace QuizSystem.Models
{
    public class Attempt
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public int QuizId { get; set; }

        public int Score { get; set; }

        public DateTime AttemptDate { get; set; } = DateTime.Now; // ✅ FIX
    }
}