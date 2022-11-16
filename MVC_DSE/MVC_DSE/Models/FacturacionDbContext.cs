using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC_DSE.Models;

public partial class FacturacionDbContext : DbContext
{
    public FacturacionDbContext()
    {
    }

    public FacturacionDbContext(DbContextOptions<FacturacionDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bitacora> Bitacoras { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<TipoCliente> TipoClientes { get; set; }

    public virtual DbSet<TipoProceso> TipoProcesos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
  //      => optionsBuilder.UseSqlServer("server=MOYA\\SQLEXPRESS; database=facturacionDB; integrated security=true;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bitacora>(entity =>
        {
            entity.HasKey(e => e.IdBitacora).HasName("PK__bitacora__223FE142E530C624");

            entity.ToTable("bitacoras");

            entity.Property(e => e.IdBitacora).HasColumnName("idBitacora");
            entity.Property(e => e.Completada).HasColumnName("completada");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.FechaVerificada)
                .HasColumnType("date")
                .HasColumnName("fechaVerificada");
            entity.Property(e => e.HoraVerificada).HasColumnName("horaVerificada");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.MontoTotal)
                .HasColumnType("money")
                .HasColumnName("montoTotal");
            entity.Property(e => e.NumReferencia)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("numReferencia");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Bitacoras)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__bitacoras__idCli__29572725");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__clientes__885457EEA7F36EA3");

            entity.ToTable("clientes");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.ApellidoCliente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidoCliente");
            entity.Property(e => e.IdTipoCliente).HasColumnName("idTipoCliente");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreCliente");

            entity.HasOne(d => d.IdTipoClienteNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdTipoCliente)
                .HasConstraintName("FK__clientes__idTipo__267ABA7A");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PK__facturas__3CD5687E4581B899");

            entity.ToTable("facturas");

            entity.Property(e => e.IdFactura).HasColumnName("idFactura");
            entity.Property(e => e.Concepto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("concepto");
            entity.Property(e => e.FechaFactura)
                .HasColumnType("date")
                .HasColumnName("fechaFactura");
            entity.Property(e => e.IdBitacora).HasColumnName("idBitacora");
            entity.Property(e => e.IdTipoProceso).HasColumnName("idTipoProceso");
            entity.Property(e => e.Valor)
                .HasColumnType("money")
                .HasColumnName("valor");

            entity.HasOne(d => d.IdBitacoraNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdBitacora)
                .HasConstraintName("FK__facturas__idBita__2F10007B");

            entity.HasOne(d => d.IdTipoProcesoNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdTipoProceso)
                .HasConstraintName("FK__facturas__idTipo__2E1BDC42");
        });

        modelBuilder.Entity<TipoCliente>(entity =>
        {
            entity.HasKey(e => e.IdTipoCliente).HasName("PK__tipoClie__FE7DCABC37C14C0C");

            entity.ToTable("tipoCliente");

            entity.Property(e => e.IdTipoCliente).HasColumnName("idTipoCliente");
            entity.Property(e => e.TipoCliente1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipoCliente");
        });

        modelBuilder.Entity<TipoProceso>(entity =>
        {
            entity.HasKey(e => e.IdTipoProceso).HasName("PK__tipoProc__619F308CF9D1CE9E");

            entity.ToTable("tipoProceso");

            entity.Property(e => e.IdTipoProceso).HasColumnName("idTipoProceso");
            entity.Property(e => e.TipoProceso1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipoProceso");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
