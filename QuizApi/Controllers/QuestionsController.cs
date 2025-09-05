using Microsoft.AspNetCore.Mvc;
using QuizApi.Models;
using QuizApi.Services;

namespace QuizApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionsController : ControllerBase
{
    private readonly QuestionService _service;

    public QuestionsController(QuestionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Question>>> GetAll()
        => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Question>> GetById(int id)
    {
        var q = await _service.GetByIdAsync(id);
        return q == null ? NotFound() : Ok(q);
    }

    [HttpPost]
    public async Task<ActionResult<Question>> Create(Question question)
    {
        var created = await _service.CreateAsync(question);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Question input)
    {
        var updated = await _service.UpdateAsync(id, input);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }

    [HttpPost("{id}/answer")]
    public async Task<IActionResult> CheckAnswer(int id, [FromQuery] int answer)
    {
        var result = await _service.CheckAnswerAsync(id, answer);
        if (result == null) return NotFound();

        return Ok(new { correct = result });
    }
}
