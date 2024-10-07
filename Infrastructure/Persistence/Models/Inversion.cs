using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Models;

public partial class Inversion
{
    public int InversionId { get; set; }

    public int InversionistaId { get; set; }

    public string CodigoInversion { get; set; } = null!;

    public int NumeroCuentaBancaria { get; set; }

    public DateTime FechaSolicitud { get; set; }

    public DateTime? FechaAprobacion { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaTermino { get; set; }

    public decimal? Monto { get; set; }

    public decimal? Interes { get; set; }

    public virtual ICollection<CuotaInversion> CuotaInversions { get; set; } = new List<CuotaInversion>();

    public virtual Inversionistum Inversionista { get; set; } = null!;

    public virtual CuentaBancarium NumeroCuentaBancariaNavigation { get; set; } = null!;
}
