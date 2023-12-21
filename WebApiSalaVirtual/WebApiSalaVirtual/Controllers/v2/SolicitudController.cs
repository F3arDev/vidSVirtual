using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSalaVirtual.Models.Data;
using WebApiSalaVirtual.Models.DbSalaVirtual;
using WebApiSalaVirtual.Models.DbSalaVirtual.Vistas;

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
            if (_context.Solicitud == null)
            {
                return NotFound();
            }
            return await _context.Solicitud
                            .ToListAsync(); // Incluye el primer objeto relacionado
                                                                     // .Include(s => s.oVwDepMunicipio) // Incluye otro objeto relacionado
                                                                     // .Include(s => s.oEstadoSolicitud) // Incluye otro objeto relacionado
        }

        // GET: api/Solicitud/5
        [MapToApiVersion("2.0")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Solicitud>> GetSolicitud(int id)
        {
            if (_context.Solicitud == null)
            {
                return NotFound();
            }
            var solicitud = await _context.Solicitud.FindAsync(id);

            if (solicitud == null)
            {
                return NotFound();
            }

            return solicitud;
        }


        [MapToApiVersion("2.0")]
        [HttpGet]
        [Route("ListaVista")]
        public async Task<ActionResult<IEnumerable<VwSolicitudDetalles>>> GetSolicitudsVista()
        {

            if (_context.VwSolicitudDetalles == null)
            {
                return NotFound();
            }
            // Obtén los datos de la vista desde el contexto de la base de datos
            var data = _context.VwSolicitudDetalles.ToListAsync();
            return await data;
        }
    }
}
