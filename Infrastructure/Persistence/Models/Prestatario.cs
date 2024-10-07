using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Models;

public partial class Prestatario
{
    public int PrestatarioId { get; set; }

    public int? ClientId { get; set; }

    public string? EstadoPrestatario { get; set; }

    public int? CantidadPrestamos { get; set; }

    public virtual Cliente? Client { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
