using System;
using System.Collections.Generic;

namespace WebApiSalaVirtual.Models.DbSalaVirtual;

public partial class LogSolicitud
{
    public int SolicitudId { get; set; }

    public int SolicitanteId { get; set; }

    public DateTime FechaRegistro { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public TimeSpan HoraInicio { get; set; }

    public TimeSpan HoraFin { get; set; }

    public int EntidadId { get; set; }

    public string Expediente { get; set; } = null!;

    public string Actividad { get; set; } = null!;

    public string UrlSesion { get; set; } = null!;

    public string Motivo { get; set; } = null!;

    public int EstadoSolicitudId { get; set; }

    public int EstadoRegistroId { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? UsuarioModificaId { get; set; }

    //public virtual Usuario? UsuarioModifica { get; set; }
}
