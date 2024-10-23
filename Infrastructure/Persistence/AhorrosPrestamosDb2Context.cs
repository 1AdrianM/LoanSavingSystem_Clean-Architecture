using System;
using System.Collections.Generic;
using System.Threading;
using Application.SeedOfWork;
using Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public partial class AhorrosPrestamosDb2Context : DbContext,IUnitOfWork
{
    public AhorrosPrestamosDb2Context()
    {
    }

    public AhorrosPrestamosDb2Context(DbContextOptions<AhorrosPrestamosDb2Context> options)
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

    public async Task<int> CompletedAsync(CancellationToken cancellation)
    {
        using var transaction = await Database.BeginTransactionAsync(cancellation);
        try
        {
            var result = await SaveChangesAsync(cancellation);
            await transaction.CommitAsync(cancellation);
            return result;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellation);
            throw;
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DbConn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Cliente__BF21A42480FCE9E1");

            entity.ToTable("Cliente");

            entity.HasIndex(e => e.Cedula, "UQ__Cliente__415B7BE5B12B455F").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Cliente__AB6E61645FE5D52F").IsUnique();

            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Cedula)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("cedula");
            entity.Property(e => e.Direccion)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<CuentaBancarium>(entity =>
        {
            entity.HasKey(e => e.NumeroCuenta);

            entity.HasIndex(e => e.NumeroCuenta, "UQ__CuentaBa__C6B74B880CF38219").IsUnique();

            entity.Property(e => e.NumeroCuenta)
                .ValueGeneratedNever()
                .HasColumnName("numero_cuenta");
            entity.Property(e => e.Banco)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("banco");
            entity.Property(e => e.TipoCuenta)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("tipoCuenta");
        });

        modelBuilder.Entity<CuotaInversion>(entity =>
        {
            entity.HasKey(e => e.CuotaId).HasName("PK__CuotaInv__0ADA8235E864DF4A");

            entity.ToTable("CuotaInversion");

            entity.Property(e => e.CuotaId).HasColumnName("cuota_id");
            entity.Property(e => e.ComprobantePago)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("comprobante_pago");
            entity.Property(e => e.Estado)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('Pendiente')")
                .HasColumnName("estado");
            entity.Property(e => e.FechaEfectiva)
                .HasColumnType("date")
                .HasColumnName("fecha_efectiva");
            entity.Property(e => e.FechaPlanificada)
                .HasColumnType("date")
                .HasColumnName("fecha_planificada");
            entity.Property(e => e.InversionId).HasColumnName("inversion_id");
            entity.Property(e => e.MontoPlanificado)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("monto_planificado");
            entity.Property(e => e.TipoModalidad)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo_modalidad");

            entity.HasOne(d => d.Inversion).WithMany(p => p.CuotaInversions)
                .HasForeignKey(d => d.InversionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_inversionId_cuota");
        });

        modelBuilder.Entity<CuotaPrestamo>(entity =>
        {
            entity.HasKey(e => e.CuotaId).HasName("PK__CuotaPre__0ADA82356223E73D");

            entity.ToTable("CuotaPrestamo");

            entity.Property(e => e.CuotaId).HasColumnName("cuota_id");
            entity.Property(e => e.ComprobantePago)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("comprobante_pago");
            entity.Property(e => e.Estado)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('Pendiente')")
                .HasColumnName("estado");
            entity.Property(e => e.FechaEfectiva)
                .HasColumnType("date")
                .HasColumnName("fecha_efectiva");
            entity.Property(e => e.FechaPlanificada)
                .HasColumnType("date")
                .HasColumnName("fecha_planificada");
            entity.Property(e => e.MontoPlanificado)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("monto_planificado");
            entity.Property(e => e.PrestamoId).HasColumnName("prestamo_id");
            entity.Property(e => e.TipoModalidad)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo_modalidad");

            entity.HasOne(d => d.Prestamo).WithMany(p => p.CuotaPrestamos)
                .HasForeignKey(d => d.PrestamoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_prestamo_cuota");
        });

        modelBuilder.Entity<Fiador>(entity =>
        {
            entity.HasKey(e => e.FiadorId).HasName("PK__Fiador__EE4802D9149B77C3");

            entity.ToTable("Fiador");

            entity.HasIndex(e => e.ClientId, "UQ__Fiador__BF21A4258A7BBBED").IsUnique();

            entity.Property(e => e.FiadorId).HasColumnName("fiador_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("estado");

            entity.HasOne(d => d.Client).WithOne(p => p.Fiador)
                .HasForeignKey<Fiador>(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_fiador");
        });

        modelBuilder.Entity<Garantium>(entity =>
        {
            entity.HasKey(e => e.GarantiaId).HasName("PK__Garantia__F036CD304D314698");

        

            entity.Property(e => e.GarantiaId)
                .ValueGeneratedOnAdd()
                .HasColumnName("garantia_id");
          
            entity.Property(e => e.TipoGarantia)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("tipoGarantia");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("ubicacion");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("valor");
        });

        modelBuilder.Entity<Inversion>(entity =>
        {
            entity.HasKey(e => e.InversionId).HasName("PK__Inversio__C50D67108395ECB8");

            entity.ToTable("Inversion");

            entity.HasIndex(e => e.CodigoInversion, "UQ__Inversio__4789C57855E1F84B").IsUnique();

            entity.Property(e => e.InversionId).HasColumnName("inversion_id");
            entity.Property(e => e.CodigoInversion)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("codigo_inversion");
            entity.Property(e => e.FechaAprobacion)
                .HasColumnType("date")
                .HasColumnName("fecha_aprobacion");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("date")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.FechaSolicitud)
                .HasColumnType("date")
                .HasColumnName("fecha_solicitud");
            entity.Property(e => e.FechaTermino)
                .HasColumnType("date")
                .HasColumnName("fecha_termino");
            entity.Property(e => e.Interes)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("interes");
            entity.Property(e => e.InversionistaId).HasColumnName("inversionista_id");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("monto");
            entity.Property(e => e.NumeroCuentaBancaria).HasColumnName("numero_cuentaBancaria");

            entity.HasOne(d => d.Inversionista).WithMany(p => p.Inversions)
                .HasForeignKey(d => d.InversionistaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_inversionista_inversion");

            entity.HasOne(d => d.NumeroCuentaBancariaNavigation).WithMany(p => p.Inversions)
                .HasForeignKey(d => d.NumeroCuentaBancaria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cuentaBancaria_inversion");
        });

        modelBuilder.Entity<Inversionistum>(entity =>
        {
            entity.HasKey(e => e.InversionistaId).HasName("PK__Inversio__8C25616455BB38AD");

            entity.Property(e => e.InversionistaId).HasColumnName("inversionista_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.EstadoInversionista)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("estado_inversionista");

            entity.HasOne(d => d.Client).WithMany(p => p.Inversionista)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("fk_inversionista")
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.PrestamoId).HasName("PK__Prestamo__C9589350B99546C3");

            entity.ToTable("Prestamo");

            entity.HasIndex(e => e.CodigoPrestamo, "UQ__Prestamo__72B18EB863B22365").IsUnique();

            entity.Property(e => e.PrestamoId).HasColumnName("prestamo_id");
            entity.Property(e => e.CodigoPrestamo)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("codigo_prestamo");
            entity.Property(e => e.FechaAprobacion)
                .HasColumnType("date")
                .HasColumnName("fecha_aprobacion");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("date")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.FechaSolicitud)
                .HasColumnType("date")
                .HasColumnName("fecha_solicitud");
            entity.Property(e => e.FechaTermino)
                .HasColumnType("date")
                .HasColumnName("fecha_termino");
            entity.Property(e => e.FiadorId).HasColumnName("fiador_id");
            entity.Property(e => e.GarantiaId).HasColumnName("garantia_id");
            entity.Property(e => e.Interes)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("interes");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("monto");
            entity.Property(e => e.PrestatarioId).HasColumnName("prestatario_id");

            entity.HasOne(d => d.Fiador).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.FiadorId)
                .HasConstraintName("fk_fiador_id");

            entity.HasOne(d => d.Garantia).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.GarantiaId)
                .HasConstraintName("fk_garantia_id");

            entity.HasOne(d => d.Prestatario).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.PrestatarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_prestatario_id");
        });

        modelBuilder.Entity<Prestatario>(entity =>
        {
            entity.HasKey(e => e.PrestatarioId).HasName("PK__Prestata__DA71A279575FCDCA");

            entity.ToTable("Prestatario");

            entity.Property(e => e.PrestatarioId).HasColumnName("prestatario_id");
            entity.Property(e => e.CantidadPrestamos)
                .HasDefaultValueSql("((0))")
                .HasColumnName("cantidad_prestamos");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.EstadoPrestatario)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("estado_prestatario");

            entity.HasOne(d => d.Client).WithMany(p => p.Prestatarios)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("fk_prestatario")
                                .OnDelete(DeleteBehavior.ClientSetNull);

        });
      /*  modelBuilder.Entity<Cliente>()
         .Navigation(c => c.Prestatarios).AutoInclude();
        modelBuilder.Entity<Cliente>()
            .Navigation(c => c.Inversionista).AutoInclude();
        modelBuilder.Entity<Cliente>()
            .Navigation(c => c.Fiador).AutoInclude();
        OnModelCreatingPartial(modelBuilder);
    */}

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
