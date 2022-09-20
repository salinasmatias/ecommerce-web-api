using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carrito> Carritos { get; set; } = null!;
        public virtual DbSet<CarritoProducto> CarritoProductos { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Orden> Ordenes { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.ToTable("Carrito");

                entity.Property(e => e.CarritoId).ValueGeneratedNever();

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.ClienteId);
            });

            modelBuilder.Entity<CarritoProducto>(entity =>
            {
                entity.HasKey(e => new { e.CarritoId, e.ProductoId });

                entity.ToTable("CarritoProducto");

                entity.HasOne(d => d.Carrito)
                    .WithMany(p => p.CarritoProductos)
                    .HasForeignKey(d => d.CarritoId);

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.CarritoProductos)
                    .HasForeignKey(d => d.ProductoId);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Apellido).HasMaxLength(25);

                entity.Property(e => e.Dni)
                    .HasMaxLength(10)
                    .HasColumnName("DNI");

                entity.Property(e => e.Nombre).HasMaxLength(25);

                entity.Property(e => e.Telefono).HasMaxLength(13);
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.ToTable("Orden");

                entity.HasIndex(e => e.CarritoId)
                    .IsUnique();

                entity.Property(e => e.OrdenId).ValueGeneratedNever();

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("decimal(15, 2)");

                entity.HasOne(d => d.Carrito)
                    .WithOne(p => p.Orden)
                    .HasForeignKey<Orden>(d => d.CarritoId);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                entity.Property(e => e.ProductoId);

                entity.Property(e => e.Codigo).HasMaxLength(25);

                entity.Property(e => e.Marca).HasMaxLength(25);

                entity.Property(e => e.Precio).HasColumnType("decimal(15, 2)");
            });
        }
    }
}
