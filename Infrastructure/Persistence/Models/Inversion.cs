using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Models;

[Table("Inversion")]
[Index("CodigoInversion", Name = "UQ__Inversio__4789C57855E1F84B", IsUnique = true)]
public partial class Inversion
{
    [Key]
    [Column("inversion_id")]
    public int InversionId { get; set; }

    [Column("inversionista_id")]
    public int InversionistaId { get; set; }

    [Column("codigo_inversion")]
    [StringLength(35)]
    [Unicode(false)]
    public string CodigoInversion { get; set; } = null!;

    [Column("numero_cuentaBancaria")]
    public int NumeroCuentaBancaria { get; set; }

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

    [InverseProperty("Inversion")]
    public virtual ICollection<CuotaInversion> CuotaInversions { get; set; } = new List<CuotaInversion>();

    [ForeignKey("InversionistaId")]
    [InverseProperty("Inversions")]
    public virtual Inversionistum Inversionista { get; set; } = null!;

    [ForeignKey("NumeroCuentaBancaria")]
    [InverseProperty("Inversions")]
    public virtual CuentaBancarium NumeroCuentaBancariaNavigation { get; set; } = null!;
}
