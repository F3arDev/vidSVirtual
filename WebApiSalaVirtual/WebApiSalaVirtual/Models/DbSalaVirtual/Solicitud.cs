using System;
using System.Collections.Generic;

namespace WebApiSalaVirtual.Models.DbSalaVirtual;

public partial class Solicitud
{
    public int? SolicitudId { get; set; }
    public int? SolicitanteId { get; set; }
    public DateTime? FechaRegistro { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public TimeSpan? HoraInicio { get; set; }
    public TimeSpan? HoraFin { get; set; }
    public int? EntidadId { get; set; }
    public string? Expediente { get; set; }
    public string? Actividad { get; set; }
    public string? UrlSesion { get; set; } 
    public string? Motivo { get; set; }
    public int? EstadoSolicitudId { get; set; }
    public int? EstadoRegistroId { get; set; }
}
