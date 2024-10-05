using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Models;

public partial class Inversionistum
{
    [Key]
    [Column("inversionista_id")]
    public int InversionistaId { get; set; }

    [Column("client_id")]
    public int ClientId { get; set; }

    [Column("estado_inversionista")]
    [StringLength(15)]
    [Unicode(false)]
    public string? EstadoInversionista { get; set; }

    [ForeignKey("ClientId")]
    [InverseProperty("Inversionista")]
    public virtual Cliente Client { get; set; } = null!;

    [InverseProperty("Inversionista")]
    public virtual ICollection<Inversion> Inversions { get; set; } = new List<Inversion>();
}
