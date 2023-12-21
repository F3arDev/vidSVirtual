using System;
using System.Collections.Generic;

namespace WebApiSalaVirtual.Models.DbSalaVirtual;

public partial class LogRefreshToken
{
    public int LogRefreshTokenId { get; set; }

    public int? UsuarioId { get; set; }

    public string? Token { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaExpiracion { get; set; }

    public bool? Estado { get; set; }

    //public virtual Usuario? Usuario { get; set; }
}
