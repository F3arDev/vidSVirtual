using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApiSalaVirtual.Models.DbSalaVirtual;
using WebApiSalaVirtual.Models.DbSalaVirtual.Vistas;

namespace WebApiSalaVirtual.Models.Data;

public partial class DbSalasVirtualesContext : DbContext
{
    public DbSalasVirtualesContext()
    {
    }

    public DbSalasVirtualesContext(DbContextOptions<DbSalasVirtualesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Entidad> Entidad { get; set; }

    public virtual DbSet<EstadoRegistro> EstadoRegistro { get; set; }

    public virtual DbSet<EstadoSolicitud> EstadoSolicitud { get; set; }

    public virtual DbSet<LogRefreshToken> LogRefreshToken { get; set; }

    public virtual DbSet<LogSolicitud> LogSolicitud { get; set; }

    public virtual DbSet<RolesRuta> RolesRuta { get; set; }

    public virtual DbSet<Solicitud> Solicitud { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<UsuarioRol> UsuarioRol { get; set; }

    public virtual DbSet<VwRolesRutas> VwRolesRutas { get; set; }

    public virtual DbSet<VwSolicitudDetalles> VwSolicitudDetalles { get; set; }

    public virtual DbSet<VwUsuarioDetalles> VwUsuarioDetalles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entidad>(entity =>
        {
            entity.HasKey(e => e.EntidadId).HasName("PK__Entidad__92A286E1C0402DDA");

            entity.ToTable("Entidad");

            entity.Property(e => e.EntidadId).HasColumnName("EntidadID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EstadoRegistro>(entity =>
        {
            entity.HasKey(e => e.EstadoRegistroId).HasName("PK__EstadoRe__29617A4B15DCFD35");

            entity.ToTable("EstadoRegistro");

            entity.Property(e => e.EstadoRegistroId).HasColumnName("EstadoRegistroID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EstadoSolicitud>(entity =>
        {
            entity.HasKey(e => e.EstadoSolicitudId).HasName("PK__EstadoSo__04D237785F7CAC0D");

            entity.ToTable("EstadoSolicitud");

            entity.Property(e => e.EstadoSolicitudId).HasColumnName("EstadoSolicitudID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(16)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LogRefreshToken>(entity =>
        {
            entity.HasKey(e => e.LogRefreshTokenId).HasName("PK__LogRefre__1CF66EB588B7B9BD");

            entity.ToTable("LogRefreshToken");

            entity.Property(e => e.LogRefreshTokenId).HasColumnName("LogRefreshTokenID");
            entity.Property(e => e.Estado).HasComputedColumnSql("(case when [FechaExpiracion]<getdate() then CONVERT([bit],(0)) else CONVERT([bit],(1)) end)", false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaExpiracion)
                .HasDefaultValueSql("(dateadd(minute,(240),getdate()))")
                .HasColumnType("datetime");
            entity.Property(e => e.RefreshToken)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Token)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            //entity.HasOne(d => d.Usuario).WithMany(p => p.LogRefreshTokens)
            //    .HasForeignKey(d => d.UsuarioId)
            //    .HasConstraintName("FK__LogRefres__Usuar__6EC0713C");
        });

        modelBuilder.Entity<LogSolicitud>(entity =>
        {
            entity.HasKey(e => e.SolicitudId).HasName("PK__LogSolic__85E95DA736F753F5");

            entity.ToTable("LogSolicitud");

            entity.Property(e => e.SolicitudId).HasColumnName("SolicitudID");
            entity.Property(e => e.Actividad)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.EntidadId).HasColumnName("EntidadID");
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

            //entity.HasOne(d => d.UsuarioModifica).WithMany(p => p.LogSolicituds)
            //    .HasForeignKey(d => d.UsuarioModificaId)
            //    .HasConstraintName("FK__LogSolici__Usuar__756D6ECB");
        });

        modelBuilder.Entity<RolesRuta>(entity =>
        {
            entity.HasKey(e => e.RutaId).HasName("PK__RolesRut__7B6199EE8696A243");

            entity.Property(e => e.RutaId).HasColumnName("RutaID");
            entity.Property(e => e.NombreRuta)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioRolId).HasColumnName("UsuarioRolID");

            //entity.HasOne(d => d.UsuarioRol).WithMany(p => p.RolesRuta)
            //    .HasForeignKey(d => d.UsuarioRolId)
            //    .HasConstraintName("FK__RolesRuta__Usuar__5CA1C101");
        });

        modelBuilder.Entity<Solicitud>(entity =>
        {
            entity.HasKey(e => e.SolicitudId).HasName("PK__Solicitu__85E95DA75FD71699");

            entity.ToTable("Solicitud");

            entity.Property(e => e.SolicitudId).HasColumnName("SolicitudID");
            entity.Property(e => e.Actividad)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.EntidadId).HasColumnName("EntidadID");
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

            //entity.HasOne(d => d.Entidad).WithMany(p => p.Solicituds)
            //    .HasForeignKey(d => d.EntidadId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK__Solicitud__Entid__681373AD");

            //entity.HasOne(d => d.EstadoRegistro).WithMany(p => p.Solicituds)
            //    .HasForeignKey(d => d.EstadoRegistroId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK__Solicitud__Estad__69FBBC1F");

            //entity.HasOne(d => d.EstadoSolicitud).WithMany(p => p.Solicituds)
            //    .HasForeignKey(d => d.EstadoSolicitudId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK__Solicitud__Estad__690797E6");

            //entity.HasOne(d => d.Solicitante).WithMany(p => p.Solicituds)
            //    .HasForeignKey(d => d.SolicitanteId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK__Solicitud__Solic__671F4F74");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE798DF16FD6C");

            entity.ToTable("Usuario");

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Departamento)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.EntidadId).HasColumnName("EntidadID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioRolId).HasColumnName("UsuarioRolID");

            //entity.HasOne(d => d.Entidad).WithMany(p => p.Usuarios)
            //    .HasForeignKey(d => d.EntidadId)
            //    .HasConstraintName("FK__Usuario__Entidad__607251E5");

            //entity.HasOne(d => d.UsuarioRol).WithMany(p => p.Usuarios)
            //    .HasForeignKey(d => d.UsuarioRolId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK__Usuario__Usuario__5F7E2DAC");
        });

        modelBuilder.Entity<UsuarioRol>(entity =>
        {
            entity.HasKey(e => e.UsuarioRolId).HasName("PK__UsuarioR__C869CD2AFC34E013");

            entity.ToTable("UsuarioRol");

            entity.Property(e => e.UsuarioRolId).HasColumnName("UsuarioRolID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwRolesRutas>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VwRolesRutas");

            entity.Property(e => e.NombreRuta)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.RutaId).HasColumnName("RutaID");
            entity.Property(e => e.UsuarioRolId).HasColumnName("UsuarioRolID");
        });

        modelBuilder.Entity<VwSolicitudDetalles>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VwSolicitudDetalles");

            entity.Property(e => e.Actividad)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Departamento)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Entidad)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.EntidadId).HasColumnName("EntidadID");
            entity.Property(e => e.EstadoRegistro)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.EstadoRegistroId).HasColumnName("EstadoRegistroID");
            entity.Property(e => e.EstadoSolicitud)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.EstadoSolicitudId).HasColumnName("EstadoSolicitudID");
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
                .IsUnicode(false);
            entity.Property(e => e.SolicitanteId).HasColumnName("SolicitanteID");
            entity.Property(e => e.SolicitanteNombre)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.SolicitudId).HasColumnName("SolicitudID");
            entity.Property(e => e.UrlSesion)
                .HasMaxLength(256)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwUsuarioDetalles>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VwUsuarioDetalles");

            entity.Property(e => e.Departamento)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Entidad)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.EntidadId).HasColumnName("EntidadID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
