using System;
using System.Collections.Generic;
using AppSorvesanWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AppSorvesanWeb.Data;

public partial class SorveteriaContext : DbContext
{
    public SorveteriaContext()
    {
    }

    public SorveteriaContext(DbContextOptions<SorveteriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ItensPedido> ItensPedidos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=JOAOPEDRO;Database=AppSorvesanDb;Trusted_Connection=True;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItensPedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ItensPed__3214EC070FD1F698");

            entity.ToTable("ItensPedido");

            entity.HasIndex(e => e.PedidoId, "IX_ItensPedido_PedidoId");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CriadoEm).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.Preco).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Quantidade).HasDefaultValue(1);

            entity.HasOne(d => d.Pedido).WithMany(p => p.ItensPedidos)
                .HasForeignKey(d => d.PedidoId)
                .HasConstraintName("FK__ItensPedi__Pedid__52593CB8");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pedidos__3214EC078FD4C342");

            entity.ToTable(tb => tb.HasTrigger("TRG_Pedidos_Atualiza_AtualizadoEm"));

            entity.HasIndex(e => e.CriadoEm, "IX_Pedidos_CriadoEm").IsDescending();

            entity.HasIndex(e => e.Status, "IX_Pedidos_Status");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AtualizadoEm).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.CriadoEm).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.NumeroPedido).HasDefaultValueSql("(NEXT VALUE FOR [dbo].[NumeroPedido_Seq])");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("novo");
            entity.Property(e => e.ValorTotal).HasColumnType("decimal(10, 2)");
        });
        modelBuilder.HasSequence("NumeroPedido_Seq").StartsAt(1000L);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
