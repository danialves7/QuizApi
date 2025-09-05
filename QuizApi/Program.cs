using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuizApi.Data;
using QuizApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configura o banco em memória
builder.Services.AddDbContext<QuizDb>(opt => opt.UseInMemoryDatabase("QuizDb"));

// Configura Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Ativa Swagger em qualquer ambiente
app.UseSwagger();
app.UseSwaggerUI();

// Endpoints da API

// GET todas as perguntas
app.MapGet("/questions", async (QuizDb db) =>
    await db.Questions.ToListAsync());

// GET pergunta específica
app.MapGet("/questions/{id}", async (int id, QuizDb db) =>
    await db.Questions.FindAsync(id) is Question q ? Results.Ok(q) : Results.NotFound());

// POST criar pergunta
app.MapPost("/questions", async (Question question, QuizDb db) =>
{
    db.Questions.Add(question);
    await db.SaveChangesAsync();
    return Results.Created($"/questions/{question.Id}", question);
});

// PUT atualizar pergunta
app.MapPut("/questions/{id}", async (int id, Question input, QuizDb db) =>
{
    var q = await db.Questions.FindAsync(id);
    if (q is null) return Results.NotFound();

    q.Text = input.Text;
    q.Options = input.Options;
    q.CorrectAnswer = input.CorrectAnswer;
    await db.SaveChangesAsync();

    return Results.NoContent();
});

// DELETE remover pergunta
app.MapDelete("/questions/{id}", async (int id, QuizDb db) =>
{
    var q = await db.Questions.FindAsync(id);
    if (q is null) return Results.NotFound();

    db.Questions.Remove(q);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

// Verificar resposta de uma pergunta
app.MapPost("/questions/{id}/answer", async (int id, int answer, QuizDb db) =>
{
    var q = await db.Questions.FindAsync(id);
    if (q is null) return Results.NotFound();

    bool isCorrect = q.CorrectAnswer == answer;
    return Results.Ok(new { correct = isCorrect });
});

app.Run();


