using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Models;

public partial class Cliente
{
    public int ClientId { get; set; }

    public string Cedula { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Email { get; set; }

    public string Apellido { get; set; } = null!;

    public string? Direccion { get; set; }

    public string Telefono { get; set; } = null!;

    public virtual Fiador? Fiador { get; set; }

    public virtual ICollection<Inversionistum> Inversionista { get; set; } = new List<Inversionistum>();

    public virtual ICollection<Prestatario> Prestatarios { get; set; } = new List<Prestatario>();
}
