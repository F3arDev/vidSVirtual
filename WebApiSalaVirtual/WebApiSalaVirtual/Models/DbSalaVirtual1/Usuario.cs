using System;
using System.Collections.Generic;

namespace WebApiSalaVirtual.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public int UsuarioRolId { get; set; }

    public int? EntidadId { get; set; }

    public string? Departamento { get; set; }

    public virtual Entidad? Entidad { get; set; }

    public virtual ICollection<LogRefreshToken> LogRefreshTokens { get; set; } = new List<LogRefreshToken>();

    public virtual ICollection<LogSolicitud> LogSolicituds { get; set; } = new List<LogSolicitud>();

    public virtual ICollection<Solicitud> Solicituds { get; set; } = new List<Solicitud>();

    public virtual UsuarioRol UsuarioRol { get; set; } = null!;
}
