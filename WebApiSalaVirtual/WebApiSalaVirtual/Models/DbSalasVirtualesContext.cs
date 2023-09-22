using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApiSalaVirtual.Models;

public partial class DbSalasVirtualesContext : DbContext
{
    public DbSalasVirtualesContext()
    {
    }

    public DbSalasVirtualesContext(DbContextOptions<DbSalasVirtualesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Entidad> Entidads { get; set; }

    public virtual DbSet<EstadoRegistro> EstadoRegistros { get; set; }

    public virtual DbSet<EstadoSolicitud> EstadoSolicituds { get; set; }

    public virtual DbSet<Solicitud> Solicituds { get; set; }

    public virtual DbSet<SolicitudHistorial> SolicitudHistorials { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioRol> UsuarioRols { get; set; }

    public virtual DbSet<VwDepMunicipio> VwDepMunicipios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entidad>(entity =>
        {
            entity.HasKey(e => e.EntidadlId).HasName("PK__Entidad__68D4A4D899D75D30");

            entity.ToTable("Entidad");

            entity.Property(e => e.EntidadlId).HasColumnName("EntidadlID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<EstadoRegistro>(entity =>
        {
            entity.HasKey(e => e.EstadoRegistroId).HasName("PK__EstadoRe__29617A4B9D8FEAE6");

            entity.ToTable("EstadoRegistro");

            entity.Property(e => e.EstadoRegistroId).HasColumnName("EstadoRegistroID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<EstadoSolicitud>(entity =>
        {
            entity.HasKey(e => e.EstadoSolicitudId).HasName("PK__EstadoSo__04D23778B756E130");

            entity.ToTable("EstadoSolicitud");

            entity.Property(e => e.EstadoSolicitudId).HasColumnName("EstadoSolicitudID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Solicitud>(entity =>
        {
            entity.HasKey(e => e.SolicitudId).HasName("PK__Solicitu__85E95DA770923B76");

            entity.ToTable("Solicitud");

            entity.Property(e => e.SolicitudId).HasColumnName("SolicitudID");
            entity.Property(e => e.Actividad)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.EstadoRegistroId)
                .HasDefaultValueSql("((1))")
                .HasColumnName("EstadoRegistroID");
            entity.Property(e => e.EstadoSolicitudId)
                .HasDefaultValueSql("((1))")
                .HasColumnName("EstadoSolicitudID");
            entity.Property(e => e.Expediente)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.FechaFin).HasColumnType("date");
            entity.Property(e => e.FechaInicio).HasColumnType("date");
            entity.Property(e => e.FechaRegistro).HasColumnType("date");
            entity.Property(e => e.HoraFin).HasPrecision(0);
            entity.Property(e => e.HoraInicio).HasPrecision(0);
            entity.Property(e => e.Motivo)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasDefaultValueSql("('Sin Motivo')");
            entity.Property(e => e.SolicitanteId).HasColumnName("SolicitanteID");
            entity.Property(e => e.UrlSesion)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasDefaultValueSql("('Sin Generar')");
            entity.Property(e => e.VwDepMunicipioId).HasColumnName("VwDepMunicipioID");

            entity.HasOne(d => d.EstadoRegistro).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.EstadoRegistroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ESTADOREGISTROID");

            entity.HasOne(d => d.EstadoSolicitud).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.EstadoSolicitudId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ESTADOSOLICITUDID");

            entity.HasOne(d => d.Solicitante).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.SolicitanteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SOLICITANTEID");

            entity.HasOne(d => d.VwDepMunicipio).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.VwDepMunicipioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VWDEPMUNICIPIOID");
        });

        modelBuilder.Entity<SolicitudHistorial>(entity =>
        {
            entity.HasKey(e => e.SolicitudId).HasName("PK__Solicitu__85E95DA77C1984E5");

            entity.ToTable("SolicitudHistorial");

            entity.Property(e => e.SolicitudId).HasColumnName("SolicitudID");
            entity.Property(e => e.Actividad)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.EstadoRegistroId)
                .HasDefaultValueSql("((1))")
                .HasColumnName("EstadoRegistroID");
            entity.Property(e => e.EstadoSolicitudId)
                .HasDefaultValueSql("((1))")
                .HasColumnName("EstadoSolicitudID");
            entity.Property(e => e.Expediente)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.FechaFin).HasColumnType("date");
            entity.Property(e => e.FechaInicio).HasColumnType("date");
            entity.Property(e => e.FechaModificacion).HasColumnType("date");
            entity.Property(e => e.FechaRegistro).HasColumnType("date");
            entity.Property(e => e.HoraFin).HasPrecision(0);
            entity.Property(e => e.HoraInicio).HasPrecision(0);
            entity.Property(e => e.Motivo)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasDefaultValueSql("('Sin Motivo')");
            entity.Property(e => e.SolicitanteId).HasColumnName("SolicitanteID");
            entity.Property(e => e.UrlSesion)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasDefaultValueSql("('Sin Generar')");
            entity.Property(e => e.UsuarioModificaId).HasColumnName("UsuarioModificaID");
            entity.Property(e => e.VwDepMunicipioId).HasColumnName("VwDepMunicipioID");

            entity.HasOne(d => d.UsuarioModifica).WithMany(p => p.SolicitudHistorials)
                .HasForeignKey(d => d.UsuarioModificaId)
                .HasConstraintName("FK_USUARIOMODIFICAID");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE7980258CECF");

            entity.ToTable("Usuario");

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioRolId).HasColumnName("UsuarioRolID");

            entity.HasOne(d => d.UsuarioRol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.UsuarioRolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USUARIOROLID");
        });

        modelBuilder.Entity<UsuarioRol>(entity =>
        {
            entity.HasKey(e => e.UsuarioRolId).HasName("PK__UsuarioR__C869CD2A9D2D5736");

            entity.ToTable("UsuarioRol");

            entity.Property(e => e.UsuarioRolId).HasColumnName("UsuarioRolID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<VwDepMunicipio>(entity =>
        {
            entity.HasKey(e => e.VwDepMunicipioId).HasName("PK__VwDepMun__8EB13FC12DE43154");

            entity.ToTable("VwDepMunicipio");

            entity.Property(e => e.VwDepMunicipioId).HasColumnName("VwDepMunicipioID");
            entity.Property(e => e.Departamento)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.EntidadlId).HasColumnName("EntidadlID");
            entity.Property(e => e.Municipio)
                .HasMaxLength(64)
                .IsUnicode(false);

            entity.HasOne(d => d.Entidadl).WithMany(p => p.VwDepMunicipios)
                .HasForeignKey(d => d.EntidadlId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ENTIDADID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
