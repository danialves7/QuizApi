using Microsoft.EntityFrameworkCore;
using QuizApi.Data;
using QuizApi.Services;

var builder = WebApplication.CreateBuilder(args);

// DB InMemory
builder.Services.AddDbContext<QuizDb>(opt => opt.UseInMemoryDatabase("QuizDb"));

// Services
builder.Services.AddScoped<QuestionService>();

// Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
