using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSalaVirtual.Models;

namespace WebApiSalaVirtual.Controllers.v2
{
    [EnableCors("ReglasCors")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")] // Crea una instancia Unica para la version de la API
    //[Route("api/[controller]")] --- manda de manera general una instancia de las funciones de la API
    [ApiVersion("2.0")] //Deprecate, Indica que la version de la API Sera Descontinuada
    public class SolicitudController : ControllerBase
    {
        private readonly DbSalasVirtualesContext _context;

        public SolicitudController(DbSalasVirtualesContext context)
        {
            _context = context;
        }

        // GET: api/Solicitud
        [MapToApiVersion("2.0")]
        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult<IEnumerable<Solicitud>>> GetSolicituds()
        {
            if (_context.Solicituds == null)
            {
                return NotFound();
            }
            return await _context.Solicituds
                            .Include(s => s.oUsuario) // Incluye el primer objeto relacionado
                            .Include(s => s.oVwDepMunicipio) // Incluye otro objeto relacionado
                            .Include(s => s.oEstadoSolicitud) // Incluye otro objeto relacionado
                            .ToListAsync();
        }

        // GET: api/Solicitud/5
        [MapToApiVersion("2.0")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Solicitud>> GetSolicitud(int id)
        {
            if (_context.Solicituds == null)
            {
                return NotFound();
            }
            var solicitud = await _context.Solicituds.FindAsync(id);

            if (solicitud == null)
            {
                return NotFound();
            }

            return solicitud;
        }
    }
}
