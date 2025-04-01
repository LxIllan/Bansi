using Microsoft.AspNetCore.Mvc.RazorPages;
using ApiExamen;
using ApiExamen.Models;
using Microsoft.AspNetCore.Mvc;

public class ExamenIndexModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public bool useSp { get; set; } = true;

    public List<Examen>? examenes { get; set; }

    public void OnGetAsync()
    {
        ClsExamen cls = new ClsExamen(useSp);
        examenes = cls.ConsultarExamen(1, "", "");
    }
}