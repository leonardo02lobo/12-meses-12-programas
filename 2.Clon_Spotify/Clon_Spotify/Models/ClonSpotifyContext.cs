using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Clon_Spotify.Models;

public partial class ClonSpotifyContext : DbContext
{
    public ClonSpotifyContext()
    {
    }

    public ClonSpotifyContext(DbContextOptions<ClonSpotifyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Artistum> Artista { get; set; }

    public virtual DbSet<Biblioteca> Bibliotecas { get; set; }

    public virtual DbSet<Cancion> Cancions { get; set; }

    public virtual DbSet<Premium> Premia { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=LEONARDO;Database=Clon_Spotify;Trusted_Connection=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Album");

            entity.Property(e => e.AlbumMusica)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Album_Musica");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.TipoCancion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Tipo_Cancion");
            entity.Property(e => e.UrlImage)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("Url_Image");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany()
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("Id_Usuario");
        });

        modelBuilder.Entity<Artistum>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Descripcion)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Genero)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.OyentesMensuales)
                .ValueGeneratedOnAdd()
                .HasColumnName("Oyentes_Mensuales");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany()
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_Id_Usuario");
        });

        modelBuilder.Entity<Biblioteca>(entity =>
        {
            entity.HasKey(e => e.BibliotecaId).HasName("PK__bibliote__E8EF3E67EFC219FA");

            entity.ToTable("biblioteca");

            entity.Property(e => e.AlbumMusica)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Album_Musica");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.Logo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("logo");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_Usuario");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cancion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Cancion");

            entity.Property(e => e.AlbumMusica)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Album_Musica");
            entity.Property(e => e.NombreMusica)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Musica");
            entity.Property(e => e.NumeroReproducciones).HasColumnName("Numero_Reproducciones");
            entity.Property(e => e.TiempoMusica)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Tiempo_Musica");
            entity.Property(e => e.UrlImage)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("Url_Image");
        });

        modelBuilder.Entity<Premium>(entity =>
        {
            entity.HasKey(e => e.IdPremium).HasName("PK__Premium__8B69E5A87B5366F8");

            entity.ToTable("Premium");

            entity.Property(e => e.IdPremium)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id_Premium");
            entity.Property(e => e.TipoPlan)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Tipo_Plan");

            entity.HasOne(d => d.IdPremiumNavigation).WithOne(p => p.Premium)
                .HasForeignKey<Premium>(d => d.IdPremium)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Id_Premium");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__63C76BE2B6A2CE0B");

            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.Contrasenia)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FotoFondo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("foto_Fondo");
            entity.Property(e => e.FotoPerfil)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("foto_Perfil");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_Usuario");
            entity.Property(e => e.Pais)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pais");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
