using System.Text;
using System.Text.Json;
using ApiExamen.Interfaces;

namespace ApiExamen.Models;

public class ApiDataAccess : IDataAccess
{
    private HttpClient httpClient;

    public ApiDataAccess()
    {
        httpClient = new HttpClient();
    }

    public (bool, string) AgregarExamen(int Id, string Nombre, string Descripcion)
    {
        string json = JsonSerializer.Serialize(new { Nombre, Descripcion });
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = Task.Run(() => httpClient.PostAsync("http://localhost:5199/api/exam", content)).Result;
        string message = response.IsSuccessStatusCode ? "Registro insertado satisfactoriamente" : "Error al insertar en base de datos.";
        return (response.IsSuccessStatusCode, message);
    }

    public bool ActualizarExamen(int Id, string Nombre, string Descripcion)
    {
        string json = JsonSerializer.Serialize(new { Nombre, Descripcion });
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = Task.Run(() => httpClient.PutAsync($"http://localhost:5199/api/exam/{Id}", content)).Result;
        return response.IsSuccessStatusCode;
    }

    public List<Examen> ConsultarExamen(int Id, string Nombre, string Descripcion)
    {
        List<Examen>? exams = new List<Examen>();
        var response = Task.Run(() => httpClient.GetAsync("http://localhost:5199/api/exam")).Result;

        if (response.IsSuccessStatusCode)
        {
            var json = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            exams = JsonSerializer.Deserialize<List<Examen>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        return exams ?? new List<Examen>();
    }

    public bool EliminarExamen(int Id)
    {
        var response = Task.Run(() => httpClient.DeleteAsync($"http://localhost:5199/api/exam/{Id}")).Result;
        return response.IsSuccessStatusCode;
    }

    public Examen getById(int Id)
    {
        Examen? examen = new Examen();
        var response = Task.Run(() => httpClient.GetAsync($"http://localhost:5199/api/exam/{Id}")).Result;
        if (response.IsSuccessStatusCode)
        {
            var json = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            examen = JsonSerializer.Deserialize<Examen>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        return examen ?? new Examen();
    }
}
