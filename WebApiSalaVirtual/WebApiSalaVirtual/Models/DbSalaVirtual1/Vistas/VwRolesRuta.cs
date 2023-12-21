using System;
using System.Collections.Generic;

namespace WebApiSalaVirtual.Models;

public partial class VwRolesRuta
{
    public int? UsuarioRolId { get; set; }

    public string Rol { get; set; } = null!;

    public int RutaId { get; set; }

    public string? NombreRuta { get; set; }
}
