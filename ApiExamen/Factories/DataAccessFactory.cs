using ApiExamen.Enums;
using ApiExamen.Interfaces;
using ApiExamen.Models;

namespace ApiExamen.Factories;

public class DataAccessFactory
{
    public static IDataAccess Create(DataAccess dataAccess)
    {
        switch (dataAccess)
        {
            case DataAccess.Api:
                return new ApiDataAccess();
            case DataAccess.SP:
                return new SpDataAccess();
            default:
                throw new NotSupportedException($"Data access method {dataAccess} is not supported.");
        }
    }
}
