using Microsoft.EntityFrameworkCore;
using QuizApi.Models;

namespace QuizApi.Data;

public class QuizDb : DbContext
{
    public QuizDb(DbContextOptions<QuizDb> options) : base(options) { }

    public DbSet<Question> Questions { get; set; } = null!;
}
