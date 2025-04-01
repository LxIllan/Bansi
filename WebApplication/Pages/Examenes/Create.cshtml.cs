using Microsoft.AspNetCore.Mvc.RazorPages;
using ApiExamen;
using ApiExamen.Models;
using Microsoft.AspNetCore.Mvc;

public class ExamenCreateModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public bool useSp { get; set; } = true;

    [BindProperty]
    public Examen examen { get; set; }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        ClsExamen cls = new ClsExamen(useSp);
        cls.AgregarExamen(examen.Nombre, examen.Descripcion);
        return RedirectToPage("Index");
    }
}