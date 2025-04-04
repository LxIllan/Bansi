using ApiExamen.Models;

namespace ApiExamen.Interfaces;

public interface IDataAccess
{
    (bool, string) AgregarExamen(string Nombre, string Descripcion);
    bool ActualizarExamen(int Id, string Nombre, string Descripcion);
    bool EliminarExamen(int Id);
    List<Examen> ConsultarExamen(int Id, string Nombre, string Descripcion);
    Examen getById(int Id);
}