using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Models;

[Table("Fiador")]
[Index("ClientId", Name = "UQ__Fiador__BF21A4258A7BBBED", IsUnique = true)]
public partial class Fiador
{
    [Key]
    [Column("fiador_id")]
    public int FiadorId { get; set; }

    [Column("client_id")]
    public int ClientId { get; set; }

    [Column("estado")]
    [StringLength(12)]
    [Unicode(false)]
    public string? Estado { get; set; }

    [ForeignKey("ClientId")]
    [InverseProperty("Fiador")]
    public virtual Cliente Client { get; set; } = null!;

    [InverseProperty("Fiador")]
    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
