using Microsoft.EntityFrameworkCore;
using QuizApi.Data;
using QuizApi.Models;

namespace QuizApi.Services
{
    public class QuestionService
    {
        private readonly QuizDb _dataBase;

        public QuestionService(QuizDb db)
        {
            _dataBase = db;
        }

        public async Task<List<Question>> GetAllAsync()
        => await _dataBase.Questions.ToListAsync();


        //Procura na Banco de dados um elemento com o ID passado 
        public async Task<Question?> GetByIdAsync(int id)
            => await _dataBase.Questions.FindAsync(id);

        public async Task<Question> CreateAsync(Question q)
        {
            _dataBase.Questions.Add(q);
            await _dataBase.SaveChangesAsync();
            return q;
        }

        public async Task<bool> UpdateAsync(int id, Question input)
        {
            var q = await _dataBase.Questions.FindAsync(id);
            if (q == null) return false;

            q.Text = input.Text;
            q.Options = input.Options;
            q.CorrectAnswer = input.CorrectAnswer;

            await _dataBase.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var q = await _dataBase.Questions.FindAsync(id);
            if (q == null) return false;

            _dataBase.Questions.Remove(q);
            await _dataBase.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> CheckAnswerAsync(int id, int answer)
        {
            var q = await _dataBase.Questions.FindAsync(id);
            if (q == null) return null;

            return q.CorrectAnswer == answer;
        }

    }
}
