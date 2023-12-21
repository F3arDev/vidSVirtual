using System;
using System.Collections.Generic;

namespace WebApiSalaVirtual.Models.DbSalaVirtual;

public partial class UsuarioRol
{
    public int UsuarioRolId { get; set; }

    public string Descripcion { get; set; } = null!;

    //public virtual ICollection<RolesRuta> RolesRuta { get; set; } = new List<RolesRuta>();

    //public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
