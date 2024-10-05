using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Models;

[Table("Prestatario")]
public partial class Prestatario
{
    [Key]
    [Column("prestatario_id")]
    public int PrestatarioId { get; set; }

    [Column("client_id")]
    public int ClientId { get; set; }

    [Column("estado_prestatario")]
    [StringLength(15)]
    [Unicode(false)]
    public string? EstadoPrestatario { get; set; }

    [Column("cantidad_prestamos")]
    public int? CantidadPrestamos { get; set; }

    [ForeignKey("ClientId")]
    [InverseProperty("Prestatarios")]
    public virtual Cliente Client { get; set; } = null!;

    [InverseProperty("Prestatario")]
    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
