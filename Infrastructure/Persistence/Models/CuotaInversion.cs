using System;
using System.Collections.Generic;
namespace Infrastructure.Persistence.Models;


public partial class CuotaInversion
{
    public int CuotaId { get; set; }

    public int InversionId { get; set; }

    public DateTime FechaPlanificada { get; set; }

    public decimal MontoPlanificado { get; set; }

    public DateTime? FechaEfectiva { get; set; }

    public string? TipoModalidad { get; set; }

    public string? ComprobantePago { get; set; }

    public string? Estado { get; set; }

    public virtual Inversion Inversion { get; set; } = null!;
}
