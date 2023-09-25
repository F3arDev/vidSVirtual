using System.Text.Json.Serialization;
namespace WebApiSalaVirtual.Models;

public partial class Entidad
{
    public int? EntidadId { get; set; }

    public string? Descripcion { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<VwDepMunicipio> VwDepMunicipios { get; set; } = new List<VwDepMunicipio>();
}
