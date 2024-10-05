using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Models;

[Index("NumeroCuenta", Name = "UQ__CuentaBa__C6B74B880CF38219", IsUnique = true)]
public partial class CuentaBancarium
{
    [Key]
    [Column("numero_cuenta")]
    public int NumeroCuenta { get; set; }

    [Column("banco")]
    [StringLength(100)]
    [Unicode(false)]
    public string Banco { get; set; } = null!;

    [Column("tipoCuenta")]
    [StringLength(30)]
    [Unicode(false)]
    public string TipoCuenta { get; set; } = null!;

    [InverseProperty("NumeroCuentaBancariaNavigation")]
    public virtual ICollection<Inversion> Inversions { get; set; } = new List<Inversion>();
}
