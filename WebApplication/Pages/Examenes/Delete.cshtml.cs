using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ApiExamen;
using ApiExamen.Models;

public class ExamenDeleteModel : PageModel
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

    public IActionResult OnPostAsync(int id)
    {
        ClsExamen cls = new ClsExamen(useSp);
        examen = cls.getById(id);
        if (examen != null)
        {
            bool isDeleted = cls.EliminarExamen(id);
        }
        return RedirectToPage("Index");
    }
}