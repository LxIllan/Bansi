using Microsoft.AspNetCore.Mvc.RazorPages;
using ApiExamen;
using ApiExamen.Models;
using Microsoft.AspNetCore.Mvc;

public class ExamenUpdateModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public bool useSp { get; set; } = true;

    [BindProperty]
    public Examen? examen { get; set; }

    public IActionResult OnGetAsync(int id)
    {
        ClsExamen cls = new ClsExamen(useSp);
        examen = cls.getById(id);
        if (examen == null)
        {
            return NotFound();
        }
        return Page();
    }

    public IActionResult OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        ClsExamen cls = new ClsExamen(useSp);
        cls.ActualizarExamen(examen.Id, examen.Nombre, examen.Descripcion);
        return RedirectToPage("Index");
    }
}