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

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //=> optionsBuilder.UseSqlServer("Server=LEONARDO;Database=API_JUEGO ;Trusted_Connection=SSPI;MultipleActiveResultSets=true;Trust Server Certificate=true");

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
            entity.Property(e => e.NombreJuego)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreJuego");
            entity.Property(e => e.PrecioLanzamiento).HasColumnName("precioLanzamiento");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
