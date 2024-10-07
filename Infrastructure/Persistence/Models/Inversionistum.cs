using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Models;

public partial class Inversionistum
{
    public int InversionistaId { get; set; }

    public int? ClientId { get; set; }

    public string? EstadoInversionista { get; set; }

    public virtual Cliente? Client { get; set; }

    public virtual ICollection<Inversion> Inversions { get; set; } = new List<Inversion>();
}
