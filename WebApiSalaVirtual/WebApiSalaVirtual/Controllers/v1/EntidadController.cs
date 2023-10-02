using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSalaVirtual.Models;

namespace WebApiSalaVirtual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntidadController : ControllerBase
    {
        private readonly DbSalasVirtualesContext _context;

        public EntidadController(DbSalasVirtualesContext context)
        {
            _context = context;
        }

        // GET: api/Entidad
        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult<IEnumerable<Entidad>>> GetEntidads()
        {
            if (_context.Entidads == null)
            {
                return NotFound();
            }
            return await _context.Entidads.ToListAsync();
        }

        // GET: api/Entidad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entidad>> GetEntidad(int id)
        {
            if (_context.Entidads == null)
            {
                return NotFound();
            }
            var entidad = await _context.Entidads.FindAsync(id);

            if (entidad == null)
            {
                return NotFound();
            }

            return entidad;
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Entidad objeto)
        {
            try
            {
                _context.Entidads.Add(objeto);
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
        public IActionResult Editar([FromBody] Entidad oEntidad)
        {
            try
            {
                // Busca el producto existente en la base de datos por su IdProducto
                var objeto = _context.UsuarioRols.Find(oEntidad.EntidadId);

                // Si el producto no existe, devuelve un BadRequest
                if (objeto == null)
                {
                    return BadRequest("Entidad no encontrado");
                }

                // Actualiza las propiedades del producto existente con los valores del producto actualizado
                objeto.Descripcion = oEntidad.Descripcion is null ? objeto.Descripcion : oEntidad.Descripcion;

                // Guarda los cambios en la base de datos   
                _context.SaveChanges();

                // Devuelve una respuesta exitosa
                return Ok(new { mensaje = "Entidad actualizado correctamente" });
            }
            catch (Exception ex)
            {
                // Si ocurre una excepción, devuelve un error con el mensaje de la excepción
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        // DELETE: api/Entidad/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntidad(int id)
        {
            if (_context.Entidads == null)
            {
                return NotFound();
            }
            var entidad = await _context.Entidads.FindAsync(id);
            if (entidad == null)
            {
                return NotFound();
            }

            _context.Entidads.Remove(entidad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //private bool EntidadExists(int id)
        //{
        //    return (_context.Entidads?.Any(e => e.EntidadId == id)).GetValueOrDefault();
        //}
    }
}
