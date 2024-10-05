using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Models;

[Table("Cliente")]
[Index("Cedula", Name = "UQ__Cliente__415B7BE5B12B455F", IsUnique = true)]
[Index("Email", Name = "UQ__Cliente__AB6E61645FE5D52F", IsUnique = true)]
public partial class Cliente
{
    [Key]
    [Column("client_id")]
    public int ClientId { get; set; }

    [Column("cedula")]
    [StringLength(35)]
    [Unicode(false)]
    public string Cedula { get; set; } = null!;

    [Column("nombre")]
    [StringLength(40)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [Column("email")]
    [StringLength(35)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("apellido")]
    [StringLength(40)]
    [Unicode(false)]
    public string Apellido { get; set; } = null!;

    [Column("direccion")]
    [StringLength(40)]
    [Unicode(false)]
    public string? Direccion { get; set; }

    [Column("telefono")]
    [StringLength(40)]
    [Unicode(false)]
    public string Telefono { get; set; } = null!;

    [InverseProperty("Client")]
    public virtual Fiador? Fiador { get; set; }

    [InverseProperty("Client")]
    public virtual ICollection<Inversionistum> Inversionista { get; set; } = new List<Inversionistum>();

    [InverseProperty("Client")]
    public virtual ICollection<Prestatario> Prestatarios { get; set; } = new List<Prestatario>();
}
