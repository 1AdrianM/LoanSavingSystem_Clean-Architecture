using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.Models;
using Application.SeedOfWork;
using System.Threading;

namespace Infrastructure.Persistence;

public partial class Loan_DbContext : DbContext,IUnitOfWork
{
    public Loan_DbContext()
    {
    }

    public Loan_DbContext(DbContextOptions<Loan_DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<CuentaBancarium> CuentaBancaria { get; set; }

    public virtual DbSet<CuotaInversion> CuotaInversions { get; set; }

    public virtual DbSet<CuotaPrestamo> CuotaPrestamos { get; set; }

    public virtual DbSet<Fiador> Fiadors { get; set; }

    public virtual DbSet<Garantium> Garantia { get; set; }

    public virtual DbSet<Inversion> Inversions { get; set; }

    public virtual DbSet<Inversionistum> Inversionista { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<Prestatario> Prestatarios { get; set; }

    public async Task<int> CompletedAsync(CancellationToken cancellationToken)
    {
        using var transaction = await Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var result = await SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return result;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-TITIKER;Initial Catalog=ahorros__prestamosDb2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Cliente__BF21A42480FCE9E1");
        });

        modelBuilder.Entity<CuentaBancarium>(entity =>
        {
            entity.Property(e => e.NumeroCuenta).ValueGeneratedNever();
        });

        modelBuilder.Entity<CuotaInversion>(entity =>
        {
            entity.HasKey(e => e.CuotaId).HasName("PK__CuotaInv__0ADA8235E864DF4A");

            entity.Property(e => e.Estado).HasDefaultValueSql("('Pendiente')");

            entity.HasOne(d => d.Inversion).WithMany(p => p.CuotaInversions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_inversionId_cuota");
        });

        modelBuilder.Entity<CuotaPrestamo>(entity =>
        {
            entity.HasKey(e => e.CuotaId).HasName("PK__CuotaPre__0ADA82356223E73D");

            entity.Property(e => e.Estado).HasDefaultValueSql("('Pendiente')");

            entity.HasOne(d => d.Prestamo).WithMany(p => p.CuotaPrestamos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_prestamo_cuota");
        });

        modelBuilder.Entity<Fiador>(entity =>
        {
            entity.HasKey(e => e.FiadorId).HasName("PK__Fiador__EE4802D9149B77C3");

            entity.HasOne(d => d.Client).WithOne(p => p.Fiador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_fiador");
        });

        modelBuilder.Entity<Garantium>(entity =>
        {
            entity.HasKey(e => e.GarantiaId).HasName("PK__Garantia__F036CD30A87354FB");

            entity.Property(e => e.GarantiaId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Inversion>(entity =>
        {
            entity.HasKey(e => e.InversionId).HasName("PK__Inversio__C50D67108395ECB8");

            entity.HasOne(d => d.Inversionista).WithMany(p => p.Inversions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_inversionista_inversion");

            entity.HasOne(d => d.NumeroCuentaBancariaNavigation).WithMany(p => p.Inversions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cuentaBancaria_inversion");
        });

        modelBuilder.Entity<Inversionistum>(entity =>
        {
            entity.HasKey(e => e.InversionistaId).HasName("PK__Inversio__8C25616455BB38AD");

            entity.HasOne(d => d.Client).WithMany(p => p.Inversionista)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_inversionista");
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.PrestamoId).HasName("PK__Prestamo__C9589350B99546C3");

            entity.HasOne(d => d.Fiador).WithMany(p => p.Prestamos).HasConstraintName("fk_fiador_id");

            entity.HasOne(d => d.Garantia).WithMany(p => p.Prestamos).HasConstraintName("fk_garantia_id");

            entity.HasOne(d => d.Prestatario).WithMany(p => p.Prestamos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_prestatario_id");
        });

        modelBuilder.Entity<Prestatario>(entity =>
        {
            entity.HasKey(e => e.PrestatarioId).HasName("PK__Prestata__DA71A279575FCDCA");

            entity.Property(e => e.CantidadPrestamos).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.Client).WithMany(p => p.Prestatarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_prestatario");
        });
        modelBuilder.Entity<Cliente>()
           .Navigation(c => c.Prestatarios).AutoInclude();
        modelBuilder.Entity<Cliente>()
            .Navigation(c => c.Inversionista).AutoInclude();
        modelBuilder.Entity<Cliente>()
            .Navigation(c => c.Fiador).AutoInclude();
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
