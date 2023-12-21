namespace WebApiSalaVirtual.Models.DbSalaVirtual;

public partial class EstadoSolicitud
{
    public int? EstadoSolicitudId { get; set; }

    public string? Descripcion { get; set; } = null!;

    //public virtual ICollection<Solicitud> Solicituds { get; set; } = new List<Solicitud>();
}
