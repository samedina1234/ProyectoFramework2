using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProyectoFramework2.Shared.Entities;

namespace ProyectoFramework2.Data;

public partial class HabitosContext : DbContext
{
    public HabitosContext()
    {
    }

    public HabitosContext(DbContextOptions<HabitosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Habito> Habitos { get; set; }

    public virtual DbSet<Subcategoria> Subcategorias { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("server=SENOXUIS\\SQLEXPRESS; database=Habitos; integrated security=true; TrustServerCertificate=Yes");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__F353C1E5EE6D4093");

            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Habito>(entity =>
        {
            entity.HasKey(e => e.HabitoId).HasName("PK__Habitos__DBBE4A77E3F11BE6");

            entity.Property(e => e.Color)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Frecuencia)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Meta)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Subcategoria).WithMany(p => p.Habitos)
                .HasForeignKey(d => d.SubcategoriaId)
                .HasConstraintName("FK__Habitos__Subcate__3C69FB99");
        });

        modelBuilder.Entity<Subcategoria>(entity =>
        {
            entity.HasKey(e => e.SubcategoriaId).HasName("PK__Subcateg__2FEBBB62FC958F6B");

            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Categoria).WithMany(p => p.Subcategoria)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK__Subcatego__Categ__398D8EEE");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__4E3E04ADA983C79F");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Apodo)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("apodo");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("genero");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre_completo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
