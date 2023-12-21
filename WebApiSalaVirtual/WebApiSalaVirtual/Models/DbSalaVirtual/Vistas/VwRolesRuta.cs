using System;
using System.Collections.Generic;

namespace WebApiSalaVirtual.Models.DbSalaVirtual.Vistas;

public partial class VwRolesRutas
{
    public int? UsuarioRolId { get; set; }

    public string Rol { get; set; } = null!;

    public int RutaId { get; set; }

    public string? NombreRuta { get; set; }
}
