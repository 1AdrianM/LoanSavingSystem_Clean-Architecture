using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Models;


public partial class CuentaBancarium
{
    public int NumeroCuenta { get; set; }

    public string Banco { get; set; } = null!;

    public string TipoCuenta { get; set; } = null!;

    public virtual ICollection<Inversion> Inversions { get; set; } = new List<Inversion>();
}
