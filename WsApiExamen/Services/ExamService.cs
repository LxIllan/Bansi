using Microsoft.EntityFrameworkCore;
using WsApiexamen.Data;
using WsApiexamen.Interfaces;
using WsApiexamen.Models;

namespace WsApiexamen.Services;

public class ExamService : IExamService
{
    private readonly DatabaseContext _context;

    public ExamService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Exam>> Get()
    {
        return await _context.Exams.ToListAsync();
    }

    public async Task<Exam?> Get(int Id)
    {
        return await _context.Exams.FindAsync(Id);
    }

    public async Task<Exam> Create(Exam exam)
    {
        _context.Exams.Add(exam);
        await _context.SaveChangesAsync();
        return exam;
    }

    public async Task<Exam> Update(int id, Exam exam)
    {
        exam.Id = id;
        try
        {
            _context.Exams.Update(exam);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            throw;
        }
        return exam;
    }

    public async Task<bool> Delete(int id)
    {
        Exam? exam = await _context.Exams.FindAsync(id);
        if (exam == null)
        {
            return false;
        }
        _context.Exams.Remove(exam);
        await _context.SaveChangesAsync();
        return true;
    }
}