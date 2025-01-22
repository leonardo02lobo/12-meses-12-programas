using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_JUEGOS.Models;

public partial class ApiJuegoContext : DbContext
{
    public ApiJuegoContext()
    {
    }

    public ApiJuegoContext(DbContextOptions<ApiJuegoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Game> Games { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=LEONARDO; Database=API_JUEGO; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Game__3213E83F87A18F96");

            entity.ToTable("Game");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnioLanzamiento).HasColumnName("anioLanzamiento");
            entity.Property(e => e.CategoriaJuego)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("categoriaJuego");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.NombreJuego)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreJuego");
            entity.Property(e => e.PrecioLanzamiento).HasColumnName("precioLanzamiento");
            entity.Property(e => e.UrlImage)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("urlImage");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
