using System;
using System.Collections.Generic;

namespace WebApiSalaVirtual.Models;

public partial class Entidad
{
    public int EntidadlId { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<VwDepMunicipio> VwDepMunicipios { get; set; } = new List<VwDepMunicipio>();
}
