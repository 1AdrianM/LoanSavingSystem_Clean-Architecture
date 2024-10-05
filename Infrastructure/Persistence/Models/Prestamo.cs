using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Models;

[Table("Prestamo")]
[Index("CodigoPrestamo", Name = "UQ__Prestamo__72B18EB863B22365", IsUnique = true)]
public partial class Prestamo
{
    [Key]
    [Column("prestamo_id")]
    public int PrestamoId { get; set; }

    [Column("prestatario_id")]
    public int PrestatarioId { get; set; }

    [Column("fiador_id")]
    public int? FiadorId { get; set; }

    [Column("garantia_id")]
    public int? GarantiaId { get; set; }

    [Column("codigo_prestamo")]
    [StringLength(35)]
    [Unicode(false)]
    public string CodigoPrestamo { get; set; } = null!;

    [Column("fecha_solicitud", TypeName = "date")]
    public DateTime FechaSolicitud { get; set; }

    [Column("fecha_aprobacion", TypeName = "date")]
    public DateTime? FechaAprobacion { get; set; }

    [Column("fecha_inicio", TypeName = "date")]
    public DateTime? FechaInicio { get; set; }

    [Column("fecha_termino", TypeName = "date")]
    public DateTime? FechaTermino { get; set; }

    [Column("monto", TypeName = "decimal(10, 2)")]
    public decimal? Monto { get; set; }

    [Column("interes", TypeName = "decimal(5, 2)")]
    public decimal? Interes { get; set; }

    [InverseProperty("Prestamo")]
    public virtual ICollection<CuotaPrestamo> CuotaPrestamos { get; set; } = new List<CuotaPrestamo>();

    [ForeignKey("FiadorId")]
    [InverseProperty("Prestamos")]
    public virtual Fiador? Fiador { get; set; }

    [ForeignKey("GarantiaId")]
    [InverseProperty("Prestamos")]
    public virtual Garantium? Garantia { get; set; }

    [ForeignKey("PrestatarioId")]
    [InverseProperty("Prestamos")]
    public virtual Prestatario Prestatario { get; set; } = null!;
}
