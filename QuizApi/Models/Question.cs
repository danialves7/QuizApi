using Microsoft.Extensions.Options;
using QuizApi.Models;

namespace QuizApi.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public List<string> Options { get; set; } = new();
        public int CorrectAnswer { get; set; } // índice da resposta correta
    }
}


{

   

}