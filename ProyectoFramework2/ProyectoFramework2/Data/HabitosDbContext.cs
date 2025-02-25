using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProyectoFramework2.Shared.Entities;

namespace ProyectoFramework2.Data;

public partial class HabitosDbContext : DbContext
{
    public HabitosDbContext()
    {
    }

    public HabitosDbContext(DbContextOptions<HabitosDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Habito> Habitos { get; set; }

    public virtual DbSet<RegistroHabito> RegistroHabitos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Server=DESKTOP-458CD4I\\SQLEXPRESS;Database=HabitosDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Habito>(entity =>
        {
            entity.HasKey(e => e.IdHabito).HasName("PK__Habitos__70FC384F5123FCAE");

            entity.Property(e => e.IdHabito).HasColumnName("id_habito");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Dificultad).HasColumnName("dificultad");
            entity.Property(e => e.Duracion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("duracion");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("activo")
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaUltimaRealizacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ultima_realizacion");
            entity.Property(e => e.Frecuencia)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("frecuencia");
            entity.Property(e => e.HoraDia)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("hora_dia");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Meta)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("meta");
            entity.Property(e => e.Motivacion)
                .HasColumnType("text")
                .HasColumnName("motivacion");
            entity.Property(e => e.Notas)
                .HasColumnType("text")
                .HasColumnName("notas");
            entity.Property(e => e.Progreso)
                .HasDefaultValue(0)
                .HasColumnName("progreso");
            entity.Property(e => e.Satisfaccion).HasColumnName("satisfaccion");
            entity.Property(e => e.Tipo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipo");
            entity.Property(e => e.Titulo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("titulo");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ubicacion");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Habitos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Habitos__id_usua__5070F446");
        });

        modelBuilder.Entity<RegistroHabito>(entity =>
        {
            entity.HasKey(e => e.IdRegistro).HasName("PK__Registro__48155C1F185BE3ED");

            entity.Property(e => e.IdRegistro).HasColumnName("id_registro");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("pendiente")
                .HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecha");
            entity.Property(e => e.IdHabito).HasColumnName("id_habito");

            entity.HasOne(d => d.IdHabitoNavigation).WithMany(p => p.RegistroHabitos)
                .HasForeignKey(d => d.IdHabito)
                .HasConstraintName("FK__RegistroH__id_ha__5535A963");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__4E3E04AD353C89DA");

            entity.HasIndex(e => e.Correo, "UQ__Usuarios__2A586E0B00F7FAE5").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.DarkMode)
                .HasDefaultValue(false)
                .HasColumnName("dark_mode");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Genero)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre_completo");
            entity.Property(e => e.Apodo)
                .HasMaxLength(60)
                .HasColumnName("apodo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
