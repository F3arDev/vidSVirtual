using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSalaVirtual.Models;

namespace WebApiSalaVirtual.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoRegistroController : ControllerBase
    {
        private readonly DbSalasVirtualesContext _context;

        public EstadoRegistroController(DbSalasVirtualesContext context)
        {
            _context = context;
        }

        // GET: api/EstadoRegistro
        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult<IEnumerable<EstadoRegistro>>> GetUsuarioRols()
        {
            if (_context.UsuarioRols == null)
            {
                return NotFound();
            }
            return await _context.EstadoRegistros.ToListAsync();
        }

        // GET: api/EstadoRegistroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoRegistro>> GetEstadoRegistro(int? id)
        {
            if (_context.EstadoRegistros == null)
            {
                return NotFound();
            }
            var estadoRegistro = await _context.EstadoRegistros.FindAsync(id);

            if (estadoRegistro == null)
            {
                return NotFound();
            }

            return estadoRegistro;
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] EstadoRegistro objeto)
        {
            try
            {
                _context.EstadoRegistros.Add(objeto);
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
        public IActionResult Editar([FromBody] EstadoRegistro oEstadoRegistro)
        {
            try
            {
                // Busca el producto existente en la base de datos por su IdProducto
                var objeto = _context.EstadoRegistros.Find(oEstadoRegistro.EstadoRegistroId);

                // Si el producto no existe, devuelve un BadRequest
                if (objeto == null)
                {
                    return BadRequest("Estado Registro no encontrado");
                }

                // Actualiza las propiedades del producto existente con los valores del producto actualizado
                objeto.Descripcion = oEstadoRegistro.Descripcion is null ? objeto.Descripcion : oEstadoRegistro.Descripcion;

                // Guarda los cambios en la base de datos   
                _context.SaveChanges();

                // Devuelve una respuesta exitosa
                return Ok(new { mensaje = "Estado Registro actualizado correctamente" });
            }
            catch (Exception ex)
            {
                // Si ocurre una excepción, devuelve un error con el mensaje de la excepción
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }


        // DELETE: api/EstadoRegistroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoRegistro(int? id)
        {
            if (_context.EstadoRegistros == null)
            {
                return NotFound();
            }
            var estadoRegistro = await _context.EstadoRegistros.FindAsync(id);
            if (estadoRegistro == null)
            {
                return NotFound();
            }

            _context.EstadoRegistros.Remove(estadoRegistro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoRegistroExists(int? id)
        {
            return (_context.EstadoRegistros?.Any(e => e.EstadoRegistroId == id)).GetValueOrDefault();
        }
    }
}
