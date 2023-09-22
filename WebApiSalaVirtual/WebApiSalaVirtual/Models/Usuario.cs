using System;
using System.Collections.Generic;

namespace WebApiSalaVirtual.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public int UsuarioRolId { get; set; }

    public virtual ICollection<SolicitudHistorial> ? SolicitudHistorials { get; set; } = new List<SolicitudHistorial>();

    public virtual ICollection<Solicitud> ? Solicituds { get; set; } = new List<Solicitud>();

    public virtual UsuarioRol ? UsuarioRol  { get; set; } = null!;
}
