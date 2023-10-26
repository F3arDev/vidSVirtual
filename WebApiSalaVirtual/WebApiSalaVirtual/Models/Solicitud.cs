namespace WebApiSalaVirtual.Models;

public partial class Solicitud
{
    public int SolicitudId { get; set; }
    public int? SolicitanteId { get; set; }
    public DateTime? FechaRegistro { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public TimeSpan? HoraInicio { get; set; }
    public TimeSpan? HoraFin { get; set; }
    public int? VwDepMunicipioId { get; set; }
    public string? Expediente { get; set; } = null!;
    public string? Actividad { get; set; } = null!;
    public string? UrlSesion { get; set; } = null!;
    public string? Motivo { get; set; } = null!;
    public int? EstadoSolicitudId { get; set; }
    public int? EstadoRegistroId { get; set; }

    // public virtual EstadoRegistro EstadoRegistro { get; set; } = null!;

    //public virtual EstadoSolicitud oEstadoSolicitud { get; set; } = null!;

    //public virtual Usuario? oUsuario { get; set; }

    //public virtual VwDepMunicipio oVwDepMunicipio { get; set; } = null!;
}
