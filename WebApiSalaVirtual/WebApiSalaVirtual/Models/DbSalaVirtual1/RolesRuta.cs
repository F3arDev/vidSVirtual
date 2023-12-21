using System;
using System.Collections.Generic;

namespace WebApiSalaVirtual.Models;

public partial class RolesRuta
{
    public int RutaId { get; set; }

    public int? UsuarioRolId { get; set; }

    public string? NombreRuta { get; set; }

    public virtual UsuarioRol? UsuarioRol { get; set; }
}
