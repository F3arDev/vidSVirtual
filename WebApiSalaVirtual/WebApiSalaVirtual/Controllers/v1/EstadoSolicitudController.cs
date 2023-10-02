using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSalaVirtual.Models;

namespace WebApiSalaVirtual.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoSolicitudController : ControllerBase
    {
        private readonly DbSalasVirtualesContext _context;

        public EstadoSolicitudController(DbSalasVirtualesContext context)
        {
            _context = context;
        }

        // GET: api/EstadoSolicitud
        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult<IEnumerable<EstadoSolicitud>>> GetEstadoSolicitud()
        {
            if (_context.EstadoSolicituds == null)
            {
                return NotFound();
            }
            return await _context.EstadoSolicituds.ToListAsync();
        }

        // GET: api/EstadoSolicitud/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoSolicitud>> GetEstadoSolicitud(int? id)
        {
            if (_context.EstadoSolicituds == null)
            {
                return NotFound();
            }
            var estadoSolicitud = await _context.EstadoSolicituds.FindAsync(id);

            if (estadoSolicitud == null)
            {
                return NotFound();
            }

            return estadoSolicitud;
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] EstadoSolicitud objeto)
        {
            try
            {
                _context.EstadoSolicituds.Add(objeto);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] EstadoSolicitud oEstadoSolicitud)
        {
            try
            {
                // Busca el producto existente en la base de datos por su IdProducto
                var objeto = _context.EstadoSolicituds.Find(oEstadoSolicitud.EstadoSolicitudId);

                // Si el producto no existe, devuelve un BadRequest
                if (objeto == null)
                {

                    return BadRequest("EstadoSolicitud no encontrado");
                }

                // Actualiza las propiedades del producto existente con los valores del producto actualizado
                objeto.Descripcion = oEstadoSolicitud.Descripcion is null ? objeto.Descripcion : oEstadoSolicitud.Descripcion;

                // Guarda los cambios en la base de datos   
                _context.SaveChanges();

                // Devuelve una respuesta exitosa
                return Ok(new { mensaje = "EstadoSolicitud actualizado correctamente" });
            }
            catch (Exception ex)
            {
                // Si ocurre una excepción, devuelve un error con el mensaje de la excepción
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }


        // DELETE: api/EstadoSolicitud/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoSolicitud(int? id)
        {
            if (_context.EstadoSolicituds == null)
            {
                return NotFound();
            }
            var estadoSolicitud = await _context.EstadoSolicituds.FindAsync(id);
            if (estadoSolicitud == null)
            {
                return NotFound();
            }

            _context.EstadoSolicituds.Remove(estadoSolicitud);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoSolicitudExists(int? id)
        {
            return (_context.EstadoSolicituds?.Any(e => e.EstadoSolicitudId == id)).GetValueOrDefault();
        }
    }
}
