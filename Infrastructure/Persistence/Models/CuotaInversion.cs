using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Models;

[Table("CuotaInversion")]
public partial class CuotaInversion
{
    [Key]
    [Column("cuota_id")]
    public int CuotaId { get; set; }

    [Column("inversion_id")]
    public int InversionId { get; set; }

    [Column("fecha_planificada", TypeName = "date")]
    public DateTime FechaPlanificada { get; set; }

    [Column("monto_planificado", TypeName = "decimal(10, 2)")]
    public decimal MontoPlanificado { get; set; }

    [Column("fecha_efectiva", TypeName = "date")]
    public DateTime? FechaEfectiva { get; set; }

    [Column("tipo_modalidad")]
    [StringLength(20)]
    [Unicode(false)]
    public string? TipoModalidad { get; set; }

    [Column("comprobante_pago")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ComprobantePago { get; set; }

    [Column("estado")]
    [StringLength(15)]
    [Unicode(false)]
    public string? Estado { get; set; }

    [ForeignKey("InversionId")]
    [InverseProperty("CuotaInversions")]
    public virtual Inversion Inversion { get; set; } = null!;
}
