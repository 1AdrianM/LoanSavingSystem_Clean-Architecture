using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Models;

public partial class Fiador
{
    public int FiadorId { get; set; }

    public int ClientId { get; set; }

    public string? Estado { get; set; }

    public virtual Cliente Client { get; set; } = null!;

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
