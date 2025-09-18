namespace QuizApi.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;

        // FK
        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;
    }
}
