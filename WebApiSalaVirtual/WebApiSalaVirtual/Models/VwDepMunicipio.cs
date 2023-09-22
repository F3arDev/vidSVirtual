using System;
using System.Collections.Generic;

namespace WebApiSalaVirtual.Models;

public partial class VwDepMunicipio
{
    public int VwDepMunicipioId { get; set; }

    public string Departamento { get; set; } = null!;

    public string Municipio { get; set; } = null!;

    public int EntidadlId { get; set; }

    public virtual Entidad Entidadl { get; set; } = null!;

    public virtual ICollection<Solicitud> Solicituds { get; set; } = new List<Solicitud>();
}
