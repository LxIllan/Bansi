using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using WsApiexamen.Interfaces;
using WsApiexamen.Models;

namespace WsApiexamen.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExamController : ControllerBase
{
    private readonly IExamService _examService;

    public ExamController(IExamService examService)
    {
        _examService = examService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Exam>>> Get()
    {
        return Ok(await _examService.Get());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Exam>> Get(int id)
    {
        Exam? exam = await _examService.Get(id);
        if (exam == null)
        {
            return NotFound();
        }
        return Ok(exam);
    }

    [HttpPost]
    public async Task<ActionResult> Create(Exam exam)
    {
        if (exam == null)
        {
            return BadRequest();
        }
        await _examService.Create(exam);
        return CreatedAtAction(nameof(Get), new { id = exam.Id }, exam);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Exam exam)
    {
        if (exam == null)
        {
            return BadRequest();
        }

        Exam updatedExam = await _examService.Update(id, exam);
        if (updatedExam == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool isExamDeleted = await _examService.Delete(id);
        return isExamDeleted ? NoContent() : NotFound();
    }
}