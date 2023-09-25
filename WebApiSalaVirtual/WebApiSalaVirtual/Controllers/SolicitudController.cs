﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSalaVirtual.Models;

namespace WebApiSalaVirtual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        private readonly DbSalasVirtualesContext _context;

        public SolicitudController(DbSalasVirtualesContext context)
        {
            _context = context;
        }

        // GET: api/Solicitud
        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult<IEnumerable<Solicitud>>> GetSolicituds()
        {
            if (_context.Solicituds == null)
            {
                return NotFound();
            }
            return await _context.Solicituds.ToListAsync();
        }

        // GET: api/Solicitud/5
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
    }
}
