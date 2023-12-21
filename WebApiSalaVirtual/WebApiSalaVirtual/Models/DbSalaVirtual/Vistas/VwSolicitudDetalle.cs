using System;
using System.Collections.Generic;

namespace WebApiSalaVirtual.Models.DbSalaVirtual.Vistas;

public partial class VwSolicitudDetalles
{
    public int SolicitudId { get; set; }

    public int SolicitanteId { get; set; }

    public string SolicitanteNombre { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public TimeSpan HoraInicio { get; set; }

    public TimeSpan HoraFin { get; set; }

    public string? Departamento { get; set; }

    public int EntidadId { get; set; }

    public string Entidad { get; set; } = null!;

    public string Expediente { get; set; } = null!;

    public string Actividad { get; set; } = null!;

    public string UrlSesion { get; set; } = null!;

    public string Motivo { get; set; } = null!;

    public int EstadoSolicitudId { get; set; }

    public string EstadoSolicitud { get; set; } = null!;

    public int EstadoRegistroId { get; set; }

    public string EstadoRegistro { get; set; } = null!;
}
