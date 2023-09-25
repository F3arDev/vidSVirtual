using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSalaVirtual.Models;

namespace WebApiSalaVirtual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioRolController : ControllerBase
    {
        private readonly DbSalasVirtualesContext _context;

        public UsuarioRolController(DbSalasVirtualesContext context)
        {
            _context = context;
        }


        // GET: api/Usuario
        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult<IEnumerable<UsuarioRol>>> GetUsuarioRols()
        {
            if (_context.UsuarioRols == null)
            {
                return NotFound();
            }
            return await _context.UsuarioRols.ToListAsync();
        }

        // GET: api/UsuarioRol/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioRol>> GetUsuarioRol(int? id)
        {
            if (_context.UsuarioRols == null)
            {
                return NotFound();
            }
            var usuarioRol = await _context.UsuarioRols.FindAsync(id);

            if (usuarioRol == null)
            {
                return NotFound();
            }

            return usuarioRol;
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] UsuarioRol objeto)
        {
            try
            {
                _context.UsuarioRols.Add(objeto);
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
        public IActionResult Editar([FromBody] UsuarioRol UsuarioRolActualizado)
        {
            try
            {
                // Busca el producto existente en la base de datos por su IdProducto
                var UsuarioRolExistente = _context.UsuarioRols.Find(UsuarioRolActualizado.UsuarioRolId);

                // Si el producto no existe, devuelve un BadRequest
                if (UsuarioRolExistente == null)
                {
                    return BadRequest("Rol no encontrado");
                }

                // Actualiza las propiedades del producto existente con los valores del producto actualizado
                UsuarioRolExistente.Descripcion = UsuarioRolActualizado.Descripcion is null ? UsuarioRolExistente.Descripcion : UsuarioRolActualizado.Descripcion;

                // Guarda los cambios en la base de datos   
                _context.SaveChanges();

                // Devuelve una respuesta exitosa
                return Ok(new { mensaje = "Rol actualizado correctamente" });
            }
            catch (Exception ex)
            {
                // Si ocurre una excepción, devuelve un error con el mensaje de la excepción
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        // DELETE: api/UsuarioRol/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioRol(int? id)
        {
            if (_context.UsuarioRols == null)
            {
                return NotFound();
            }
            var usuarioRol = await _context.UsuarioRols.FindAsync(id);
            if (usuarioRol == null)
            {
                return NotFound();
            }

            _context.UsuarioRols.Remove(usuarioRol);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioRolExists(int? id)
        {
            return (_context.UsuarioRols?.Any(e => e.UsuarioRolId == id)).GetValueOrDefault();
        }
    }
}