using System.Text.Json.Serialization;

namespace WebApiSalaVirtual.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }
    public string? Nombre { get; set; } = null!;
    public int? UsuarioRolId { get; set; }

    public static implicit operator Usuario(string v)
    {
        throw new NotImplementedException();
    }

    // [JsonIgnore]
    // public virtual UsuarioRol? oRolUsuario { get; set; } = null!;

    // public virtual ICollection<SolicitudHistorial>? SolicitudHistorials { get; set; } = new List<SolicitudHistorial>();
    //[JsonIgnore]
    //public virtual ICollection<Solicitud>? Solicituds { get; set; } = new List<Solicitud>();
}
