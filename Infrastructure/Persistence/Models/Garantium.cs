using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Models;

public partial class Garantium
{
    public int GarantiaId { get; set; }

    public string? TipoGarantia { get; set; }

    public decimal? Valor { get; set; }

    public string? Ubicacion { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
