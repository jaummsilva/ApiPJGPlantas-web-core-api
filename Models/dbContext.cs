using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace apiteste.Models
{
    public partial class dbContext : DbContext
    {
        public dbContext()
        {
        }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Boleto> Boletoes { get; set; } = null!;
        public virtual DbSet<Cartao> Cartaos { get; set; } = null!;
        public virtual DbSet<Comentario> Comentarios { get; set; } = null!;
        public virtual DbSet<Compra> Compras { get; set; } = null!;
        public virtual DbSet<ItemCompra> ItemCompras { get; set; } = null!;
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; } = null!;
        public virtual DbSet<Pix> Pixes { get; set; } = null!;
        public virtual DbSet<Planta> Plantas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-PC02EDM;Database=ContosoUniversity1;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cartao>(entity =>
            {
                entity.HasIndex(e => e.UsuarioId, "IX_UsuarioID");

                entity.Property(e => e.Cvv)
                    .HasMaxLength(3)
                    .HasColumnName("CVV");

                entity.Property(e => e.NomeTitular).HasMaxLength(200);

                entity.Property(e => e.Numero).HasMaxLength(19);

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.Property(e => e.Validade).HasMaxLength(5);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Cartaos)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_dbo.Cartaos_dbo.Usuarios_UsuarioID");
            });

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.HasIndex(e => e.PlantaId, "IX_PlantaId");

                entity.HasIndex(e => e.UsuarioId, "IX_UsuarioId");

                entity.Property(e => e.Dth).HasColumnType("datetime");

                entity.HasOne(d => d.Planta)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.PlantaId)
                    .HasConstraintName("FK_dbo.Comentarios_dbo.Plantas_PlantaId");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_dbo.Comentarios_dbo.Usuarios_UsuarioId");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasIndex(e => e.BoletoId, "IX_BoletoId");

                entity.HasIndex(e => e.CartaoId, "IX_CartaoId");

                entity.HasIndex(e => e.PixId, "IX_PixId");

                entity.HasIndex(e => e.UsuarioId, "IX_UsuarioId");

                entity.HasOne(d => d.Boleto)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.BoletoId)
                    .HasConstraintName("FK_dbo.Compras_dbo.Boletoes_BoletoId");

                entity.HasOne(d => d.Cartao)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.CartaoId)
                    .HasConstraintName("FK_dbo.Compras_dbo.Cartaos_CartaoId");

                entity.HasOne(d => d.Pix)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.PixId)
                    .HasConstraintName("FK_dbo.Compras_dbo.Pixes_PixId");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_dbo.Compras_dbo.Usuarios_UsuarioId");
            });

            modelBuilder.Entity<ItemCompra>(entity =>
            {
                entity.HasIndex(e => e.CompraId, "IX_CompraId");

                entity.HasIndex(e => e.PlantaId, "IX_PlantaId");

                entity.Property(e => e.Dth).HasColumnType("datetime");

                entity.HasOne(d => d.Compra)
                    .WithMany(p => p.ItemCompras)
                    .HasForeignKey(d => d.CompraId)
                    .HasConstraintName("FK_dbo.ItemCompras_dbo.Compras_CompraId");

                entity.HasOne(d => d.Planta)
                    .WithMany(p => p.ItemCompras)
                    .HasForeignKey(d => d.PlantaId)
                    .HasConstraintName("FK_dbo.ItemCompras_dbo.Plantas_PlantaId");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
