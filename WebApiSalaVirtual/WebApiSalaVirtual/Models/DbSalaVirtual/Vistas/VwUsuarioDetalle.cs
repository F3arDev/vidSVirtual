using System;
using System.Collections.Generic;

namespace WebApiSalaVirtual.Models.DbSalaVirtual.Vistas;

public partial class VwUsuarioDetalles
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public int RolId { get; set; }

    public string Rol { get; set; } = null!;

    public string? Departamento { get; set; }

    public int EntidadId { get; set; }

    public string Entidad { get; set; } = null!;
}
