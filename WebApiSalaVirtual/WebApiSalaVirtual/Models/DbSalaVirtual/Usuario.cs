using System.Text.Json.Serialization;

namespace WebApiSalaVirtual.Models.DbSalaVirtual;

public partial class Usuario
{
    public int UsuarioId { get; set; }
    public string? Nombre { get; set; } = null!;
    public int? UsuarioRolId { get; set; }
    public int? EntidadID { get; set; }

    public static implicit operator Usuario(string v)
    {
        throw new NotImplementedException();
    }
}
