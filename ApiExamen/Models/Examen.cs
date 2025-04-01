namespace ApiExamen.Models;

public class Examen
{
    public int Id { set; get; } // Se cambia de IdExam a Id, para reutilizar la clase.
    public string Nombre { set; get; } = string.Empty;
    public string Descripcion { set; get; } = string.Empty;
}