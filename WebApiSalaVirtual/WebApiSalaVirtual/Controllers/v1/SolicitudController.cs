using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSalaVirtual.Models;
using System.Linq;
namespace WebApiSalaVirtual.Controllers.v1
{
    [EnableCors("ReglasCors")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")] // Crea una instancia Unica para la version de la API
    //[Route("api/[controller]")] --- manda de manera general una instancia de las funciones de la API
    [ApiVersion("1.0")] //Deprecate, Indica que la version de la API Sera Descontinuada
    public class SolicitudController : ControllerBase
    {
        private readonly DbSalasVirtualesContext _context;

        public SolicitudController(DbSalasVirtualesContext context)
        {
            _context = context;
        }

        [MapToApiVersion("1.0")]
        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult<IEnumerable<VwSolicitudDetalles>>> GetSolicitudsVista()
        {

            if (_context.VwSolicitudDetalles == null)
            {
                return NotFound();
            }
            // Obtén los datos de la vista desde el contexto de la base de datos
            var lista = _context.VwSolicitudDetalles.Take(100).ToListAsync();

            return await lista;
        }

        [MapToApiVersion("1.0")]
        [HttpGet]
        [Route("ListaPEN")]
        public IActionResult ListaPendiente()
        {
            List<VwSolicitudDetalles> lista = new List<VwSolicitudDetalles>();
            try
            {
                // Filtrar solicitudes pendientes por EstadoSolicitudId igual a un valor específico (por ejemplo, 1 para estado pendiente)
                lista = _context.VwSolicitudDetalles.Where(s => s.EstadoSolicitudID == 1).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ok", response = lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, respuesta = lista });
            }
        }

        [MapToApiVersion("1.0")]
        [HttpGet]
        [Route("ListaRegUsuario/{solicitanteId}")]
        public IActionResult ListaRegUSUARIO(int solicitanteId)
        {
            List<VwSolicitudDetalles> lista = new List<VwSolicitudDetalles>();
            try
            {
                // Filtrar solicitudes por el solicitanteId proporcionado en la URL
                lista = _context.VwSolicitudDetalles.Where(s => s.SolicitanteID == solicitanteId).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ok", response = lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, respuesta = lista });
            }
        }

        [MapToApiVersion("1.0")]
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Solicitud objeto)
        {
            try
            {
                _context.Solicituds.Add(objeto);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [MapToApiVersion("1.0")]
        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Solicitud oSolicitud)
        {
            try
            {
                // Busca el producto existente en la base de datos por su IdProducto
                var objeto = _context.Solicituds.Find(oSolicitud.SolicitudId);

                // Si el producto no existe, devuelve un BadRequest
                if (objeto == null)
                {
                    return BadRequest("Solicitud  no encontrado");
                }

                // Actualiza las propiedades del producto existente con los valores del producto actualizado
                objeto.EstadoSolicitudId = oSolicitud.EstadoSolicitudId is null ? objeto.EstadoSolicitudId : oSolicitud.EstadoSolicitudId;
                objeto.EstadoRegistroId = oSolicitud.EstadoRegistroId is null ? objeto.EstadoRegistroId : oSolicitud.EstadoRegistroId;

                // Guarda los cambios en la base de datos   
                _context.SaveChanges();

                // Devuelve una respuesta exitosa
                return Ok(new { mensaje = "Estado Solicitud actualizado correctamente" });
            }
            catch (Exception ex)
            {
                // Si ocurre una excepción, devuelve un error con el mensaje de la excepción
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }





        // GET: api/Solicitud
        //[MapToApiVersion("1.0")]
        //[HttpGet]
        //[Route("Lista")]
        //public async Task<ActionResult<IEnumerable<Solicitud>>> GetSolicituds()
        //{
        //    if (_context.Solicituds == null)
        //    {
        //        return NotFound();
        //    }


        //    return await _context.Solicituds.ToListAsync();
        //}



        // GET: api/Solicitud/5
        //[MapToApiVersion("1.0")]
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Solicitud>> GetSolicitud(int id)
        //{
        //    if (_context.Solicituds == null)
        //    {
        //        return NotFound();
        //    }
        //    var solicitud = await _context.Solicituds.FindAsync(id);

        //    if (solicitud == null)
        //    {
        //        return NotFound();
        //    }

        //    return solicitud;
        //}
    }
}
