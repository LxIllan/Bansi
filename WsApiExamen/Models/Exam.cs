using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WsApiexamen.Models;

[Table("tblExamen")]
public class Exam
{
    [Column("idExamen")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("Nombre")]
    public string Nombre { get; set; } = string.Empty;

    [Column("Descripcion")]
    public string Descripcion { get; set; } = string.Empty;
}