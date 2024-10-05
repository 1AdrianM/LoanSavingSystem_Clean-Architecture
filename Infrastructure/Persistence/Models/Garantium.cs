using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Models;

[Index("CodigoGarantia", Name = "UQ__Garantia__712CC185AA793DE9", IsUnique = true)]
public partial class Garantium
{
    [Key]
    [Column("garantia_id")]
    public int GarantiaId { get; set; }

    [Column("codigo_garantia")]
    public int CodigoGarantia { get; set; }

    [Column("tipoGarantia")]
    [StringLength(40)]
    [Unicode(false)]
    public string? TipoGarantia { get; set; }

    [Column("valor", TypeName = "decimal(10, 2)")]
    public decimal? Valor { get; set; }

    [Column("ubicacion")]
    [StringLength(40)]
    [Unicode(false)]
    public string? Ubicacion { get; set; }

    [InverseProperty("Garantia")]
    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
