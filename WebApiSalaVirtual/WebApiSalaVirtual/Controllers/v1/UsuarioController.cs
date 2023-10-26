using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSalaVirtual.Models;

namespace WebApiSalaVirtual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DbSalasVirtualesContext _context;

        public UsuarioController(DbSalasVirtualesContext context)
        {
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            if (_context.Usuarios == null)
            {
                return NotFound();
            }
            return await _context.Usuarios./*Include(c => c.oRolUsuario)*/ToListAsync();
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            if (_context.Usuarios == null)
            {
                return NotFound();
            }
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Usuario objeto)
        {
            try
            {
                _context.Usuarios.Add(objeto);
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
        public IActionResult Editar([FromBody] Usuario UsuarioActualizado)
        {
            try
            {
                // Busca el producto existente en la base de datos por su IdProducto
                var UsuarioExistente = _context.Usuarios.Find(UsuarioActualizado.UsuarioId);

                // Si el producto no existe, devuelve un BadRequest
                if (UsuarioExistente == null)
                {
                    return BadRequest("Producto no encontrado");
                }

                // Actualiza las propiedades del producto existente con los valores del producto actualizado
                UsuarioExistente.Nombre = UsuarioActualizado.Nombre is null ? UsuarioExistente.Nombre : UsuarioActualizado.Nombre;
                UsuarioExistente.UsuarioRolId = UsuarioActualizado.UsuarioRolId is null ? UsuarioExistente.UsuarioRolId : UsuarioActualizado.UsuarioRolId;


                // Guarda los cambios en la base de datos   
                _context.SaveChanges();

                // Devuelve una respuesta exitosa
                return Ok(new { mensaje = "Producto actualizado correctamente" });
            }
            catch (Exception ex)
            {
                // Si ocurre una excepción, devuelve un error con el mensaje de la excepción
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }



        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            if (_context.Usuarios == null)
            {
                return NotFound();
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //private bool UsuarioExists(int id)
        //{
        //    return (_context.Usuarios?.Any(e => e.UsuarioId == id)).GetValueOrDefault();
        //}
    }
}
