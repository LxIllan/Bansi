using ApiExamen.Factories;
using ApiExamen.Interfaces;
using ApiExamen.Enums;

namespace ApiExamen;

public class ClsExamen
{
    private readonly IDataAccess dataAccess;

    public ClsExamen(bool useSp)
    {
        dataAccess = DataAccessFactory.Create(useSp ? DataAccess.SP : DataAccess.Api);
    }

    public (bool, string) AgregarExamen(int Id, string Nombre, string Descripcion)
    {
        return dataAccess.AgregarExamen(Id, Nombre, Descripcion);
    }

    public bool ActualizarExamen(int Id, string Nombre, string Descripcion)
    {
        return dataAccess.ActualizarExamen(Id, Nombre, Descripcion);
    }

    public bool EliminarExamen(int Id)
    {
        return dataAccess.EliminarExamen(Id);
    }
    public bool ConsultarExamen(int Id, string Nombre, string Descripcion)
    {
        return dataAccess.ActualizarExamen(Id, Nombre, Descripcion);
    }

    public void PrintInstance()
    {
        dataAccess.printInstance();
    }
}
