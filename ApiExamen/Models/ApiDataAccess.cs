using ApiExamen.Interfaces;

namespace ApiExamen.Models;

public class ApiDataAccess : IDataAccess
{
    public (bool, string) AgregarExamen(int Id, string Nombre, string Descripcion)
    {
        throw new NotImplementedException();
    }
    public bool ActualizarExamen(int Id, string Nombre, string Descripcion)
    {
        throw new NotImplementedException();
    }

    public bool ConsultarExamen(int Id, string Nombre, string Descripcion)
    {
        throw new NotImplementedException();
    }

    public bool EliminarExamen(int Id)
    {
        throw new NotImplementedException();
    }

    public void printInstance()
    {
        System.Console.WriteLine("ApiDataAccess");
    }
}