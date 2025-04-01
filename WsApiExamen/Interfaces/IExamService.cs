using WsApiexamen.Models;

namespace WsApiexamen.Interfaces;

public interface IExamService
{
    Task<IEnumerable<Exam>> Get();
    Task<Exam?> Get(int Id);
    Task<Exam> Create(Exam exam);
    Task<Exam> Update(int id, Exam exam);
    Task<bool> Delete(int id);
}