using System.Text.Json.Serialization;

namespace WebApiSalaVirtual.Models.DbSalaVirtual;

public partial class Entidad
{
    public int? EntidadId { get; set; }
    public string? Descripcion { get; set; } = null!;

}
