using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApiSalaVirtual.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiSalaVirtual.Models;
using WebApiSalaVirtual.Models.Auth;
using WebApiSalaVirtual.Models.Auth.VwAuth;
using Microsoft.AspNetCore.Authorization;



namespace WebApiSalaVirtual.Controllers.v1
{
    [EnableCors("ReglasCors")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")] // Crea una instancia Unica para la version de la API
    //[Route("api/[controller]")] --- manda de manera general una instancia de las funciones de la API
    [ApiVersion("1.0")]
    public class AuthController : ControllerBase
    {
        private readonly IAutorizacionService _autorizacionService;
        private readonly DbSalasVirtualesContext _context;
        public AuthController(IAutorizacionService autorizacionService, DbSalasVirtualesContext context)
        {
            _autorizacionService = autorizacionService;
            _context = context;
        }

        [HttpPost]
        [Route("Autenticar")]
        public async Task<IActionResult> Autenticar([FromBody] AuthUser autorizacion)
        {
            var Respuesta = await _autorizacionService.DevolverToken(autorizacion);
            if (Respuesta == null)
            {
                return Unauthorized();
            }
            return Ok(new { Mensaje = "ok", Respuesta });
        }

        [HttpPost]
        [Route("ObtenerRefreshToken")]
        public async Task<IActionResult> ObtenerRefreshToken([FromBody] RefreshTokenRequest request)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var TokenExpiradoSupuestamente = tokenHandler.ReadJwtToken(request.TokenExpirado);

            if (TokenExpiradoSupuestamente.ValidTo > DateTime.UtcNow)
            {
                return BadRequest(new  { Respuesta = false, Mensaje = "Token no ha Expidaro" });
            }

            string UsuarioID = TokenExpiradoSupuestamente.Claims.First(x =>
                x.Type == JwtRegisteredClaimNames.NameId).Value.ToString();

            var autorizacionResponse = await _autorizacionService.DevolverRefreshToken(request, int.Parse(UsuarioID));

            if (autorizacionResponse == null)
            {
                return Unauthorized();
            }

            return Ok(autorizacionResponse);
        }

        [HttpPost]
        [Authorize]
        [Route("ValidarRuta")]
        public IActionResult ValidarRuta([FromBody] AuthRuta request)
        {
            var user = null as VwRolesRutas;
            user = _context.VwRolesRutas.FirstOrDefault(obj => obj.Rol == request.Rol && obj.NombreRuta == request.Ruta);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { mensaje = "Usuario sin Autorizacion de la Ruta", response = new { auth = false } });
            }
            return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = new { auth = true } });
        }
    }
}
