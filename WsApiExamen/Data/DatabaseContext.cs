using Microsoft.EntityFrameworkCore;
using WsApiexamen.Models;

namespace WsApiexamen.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<Exam> Exams { get; set; }
}