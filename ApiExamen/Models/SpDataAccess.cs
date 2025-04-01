using ApiExamen.Interfaces;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ApiExamen.Models;

public class SpDataAccess : IDataAccess
{
    private readonly string ConnectionString;

    public SpDataAccess()
    {
        ConnectionString = @"Server=NADIA\SQLEXPRESS;Database=BdiExamen;Integrated Security=True;TrustServerCertificate=True;";
    }

    public (bool, string) AgregarExamen(int Id, string Nombre, string Descripcion)
    {
        bool isCreated = false;
        string message = "";
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("spAgregar", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = Id });
                cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = Nombre });
                cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar) { Value = Descripcion });

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        isCreated = (int)reader["Code"] == 0;
                        message = (string)reader["Message"];
                    }
                }
                connection.Close();
            }
        }
        return (isCreated, message);
    }
    public bool ActualizarExamen(int Id, string Nombre, string Descripcion)
    {
        bool isUpdated = false;
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("spActualizar", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = Id });
                cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = Nombre });
                cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar) { Value = Descripcion });

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        isUpdated = (int)reader["Code"] == 0;
                    }
                }
                connection.Close();
            }
        }
        return isUpdated;
    }

    public List<Examen> ConsultarExamen(int Id, string Nombre, string Descripcion)
    {
        List<Examen> examens = new List<Examen>();
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("spConsultar", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                // cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = Id });
                cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = Nombre });
                cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar) { Value = Descripcion });

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        examens.Add(new Examen
                        {
                            Id = (int)reader["idExamen"],
                            Nombre = (string)reader["Nombre"],
                            Descripcion = (string)reader["Descripcion"]
                        });
                    }
                }
                connection.Close();
            }
        }
        return examens;
    }

    public bool EliminarExamen(int Id)
    {
        bool isDeleted = false;
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("spEliminar", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = Id });

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        isDeleted = (int)reader["Code"] == 0;
                    }
                }
                connection.Close();
            }
        }
        return isDeleted;
    }

    public void printInstance()
    {
        Console.WriteLine("SpDataAccess");
    }
}