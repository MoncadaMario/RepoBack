using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepoBackEnd.Models;
[Table("productos")]
public class Producto
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("nombre")]
    public string Nombre { get; set; }

    [Column("categoria")]
    public string Categoria { get; set; }

    [Column("precio")]
    public decimal Precio { get; set; }

    [Column("cantidad")]
    public int Cantidad { get; set; }



}
