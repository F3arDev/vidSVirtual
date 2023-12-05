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



namespace WebApiSalaVirtual.Controllers.v1
{
    [Route("api/[controller]")]
    [EnableCors("ReglasCors")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAutorizacionService _autorizacionService;

        public AuthController(IAutorizacionService autorizacionService)
        {
            _autorizacionService = autorizacionService;
        }

        [HttpPost]
        [Route("Autenticar")]
        public async Task<IActionResult> Autenticar([FromBody] AuthUser autorizacion)
        {
            var resultado_autorizacion = await _autorizacionService.DevolverToken(autorizacion);
            if (resultado_autorizacion == null)
                return Unauthorized();

            return Ok(resultado_autorizacion);
        }

        [HttpPost]
        [Route("ObtenerRefreshToken")]
        public async Task<IActionResult> ObtenerRefreshToken([FromBody] RefreshTokenRequest request)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var TokenExpiradoSupuestamente = tokenHandler.ReadJwtToken(request.TokenExpirado);

            if (TokenExpiradoSupuestamente.ValidTo > DateTime.Now)
            {
                return BadRequest(new AuthReponse { Resultado = false, Msg = "Token no ha Expidaro" });
            }

            string UsuarioID = TokenExpiradoSupuestamente.Claims.First(x =>
                x.Type == JwtRegisteredClaimNames.NameId).Value.ToString();

            // var autorizacionResponse = await _autorizacionService.DevolverRefreshToken(request, int.Parse(UsuarioID));
            var autorizacionResponse = await _autorizacionService.DevolverRefreshToken(request, int.Parse(UsuarioID));
            if (autorizacionResponse == null)
            {
                return Unauthorized();
            }
            return Ok(autorizacionResponse);
        }

        //[HttpPost]
        //[Route("ValidarRuta")]
        //public IActionResult ValidarRuta([FromBody] AuthRuta request)
        //{
        //    var user = null as VwRolesRutas;
        //    user = _context.VwRolesRutas.FirstOrDefault(obj => obj.Rol == request.Rol && obj.NombreRuta == request.Ruta);
        //    if (user == null)
        //    {
        //        return StatusCode(StatusCodes.Status401Unauthorized, new { mensaje = "Usuario sin Autorizacion de la Ruta", response = new { auth = false } });
        //    }
        //    return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = new { auth = true } });
        //}
    }
}
