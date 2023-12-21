using System;
using System.Collections.Generic;

namespace WebApiSalaVirtual.Models.DbSalaVirtual.Vistas;

public partial class VwDepMunicipio
{
    public int VwDepMunicipioId { get; set; }

    public string Departamento { get; set; } = null!;

    public string Municipio { get; set; } = null!;

    public int EntidadID { get; set; }

    public virtual Entidad oEntidad { get; set; } = null!;

    // public virtual ICollection<Solicitud> Solicituds { get; set; } = new List<Solicitud>();
}
