namespace ApiExamen.Interfaces;

public interface IDataAccess
{
    (bool, string) AgregarExamen(int Id, string Nombre, string Descripcion);
    bool ActualizarExamen(int Id, string Nombre, string Descripcion);
    bool EliminarExamen(int Id);
    bool ConsultarExamen(int Id, string Nombre, string Descripcion);
    void printInstance();
}