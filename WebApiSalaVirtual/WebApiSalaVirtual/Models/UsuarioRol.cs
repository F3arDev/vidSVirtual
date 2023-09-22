using System;
using System.Collections.Generic;

namespace WebApiSalaVirtual.Models;

public partial class UsuarioRol
{
    public int UsuarioRolId { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
