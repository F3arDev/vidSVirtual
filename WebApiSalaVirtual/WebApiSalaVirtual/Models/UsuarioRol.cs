using System.Text.Json.Serialization;

namespace WebApiSalaVirtual.Models;

public partial class UsuarioRol
{
    public int? UsuarioRolId { get; set; }

    public string? Descripcion { get; set; } = null!;

    // [JsonIgnore]
    // public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}