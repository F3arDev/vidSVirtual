﻿using System;
using System.Collections.Generic;

namespace WebApiSalaVirtual.Models.DbSalaVirtual;

public partial class EstadoRegistro
{
    public int EstadoRegistroId { get; set; }

    public string Descripcion { get; set; } = null!;

    //public virtual ICollection<Solicitud> Solicituds { get; set; } = new List<Solicitud>();
}
