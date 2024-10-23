using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Models;

public partial class Prestamo
{
    public int PrestamoId { get; set; }

    public int PrestatarioId { get; set; }

    public int? FiadorId { get; set; }

    public int? GarantiaId { get; set; }

    public string CodigoPrestamo { get; set; } = null!;

    public DateTime FechaSolicitud { get; set; }

    public DateTime? FechaAprobacion { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaTermino { get; set; }   

    public decimal? Monto { get; set; }

    public decimal? Interes { get; set; }

    public virtual ICollection<CuotaPrestamo> CuotaPrestamos { get; set; } = new List<CuotaPrestamo>();

    public virtual Fiador? Fiador { get; set; }

    public virtual Garantium? Garantia { get; set; }

    public virtual Prestatario Prestatario { get; set; } = null!;
}
