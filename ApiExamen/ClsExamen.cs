using ApiExamen.Factories;
using ApiExamen.Interfaces;
using ApiExamen.Enums;
using ApiExamen.Models;

namespace ApiExamen;

public class ClsExamen
{
    private readonly IDataAccess dataAccess;

    public ClsExamen(bool useSp)
    {
        dataAccess = DataAccessFactory.Create(useSp ? DataAccess.SP : DataAccess.Api);
    }

    public (bool, string) AgregarExamen(string Nombre, string Descripcion)
    {
        if (string.IsNullOrEmpty(Nombre) && string.IsNullOrEmpty(Descripcion))
        {
            return (false, "Error, ambos parámetros no pueden ser nulos o vacíos.");
        }
        return dataAccess.AgregarExamen(Nombre, Descripcion);
    }

    public bool ActualizarExamen(int Id, string Nombre, string Descripcion)
    {
        if (string.IsNullOrEmpty(Nombre) && string.IsNullOrEmpty(Descripcion))
        {
            return false;
        }
        return dataAccess.ActualizarExamen(Id, Nombre, Descripcion);
    }

    public bool EliminarExamen(int Id)
    {
        if (Id < 1)
        {
            return false;
        }
        return dataAccess.EliminarExamen(Id);
    }

    public List<Examen> ConsultarExamen(int Id, string Nombre, string Descripcion)
    {
        return dataAccess.ConsultarExamen(Id, Nombre, Descripcion);
    }

    public Examen getById(int Id)
    {
        if (Id < 1)
        {
            return null;
        }
        return dataAccess.getById(Id);
    }
}
