using System;
using System.Collections.Generic;

namespace WebApiSalaVirtual.Models;

public partial class Entidad
{
    public int EntidadId { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Solicitud> Solicituds { get; set; } = new List<Solicitud>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
