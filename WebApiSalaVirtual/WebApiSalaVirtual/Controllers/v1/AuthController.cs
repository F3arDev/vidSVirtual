using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiSalaVirtual.Models;
using WebApiSalaVirtual.Models.Auth;



namespace WebApiSalaVirtual.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly string secretKey;
        private readonly DbSalasVirtualesContext _context;
        
        public AuthController(IConfiguration config, DbSalasVirtualesContext context)
        {
            secretKey = config.GetSection("settings").GetSection("secretKey").ToString();
            _context = context;
        }

        [HttpPost]
        [Route("Validar")]
        public IActionResult Validar([FromBody] AuthUser request)
        {
            try
            {
                var user = null as VwUsuarioDetalles;
                user = _context.VwUsuarioDetalles.FirstOrDefault(obj => obj.Nombre == request.Nombre && obj.Rol == request.Rol);

                if (user == null)
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, new { Auth = "Usuario sin Autorizacion" });
                }


                var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.Nombre));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(240),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
                string tokencreado = tokenHandler.WriteToken(tokenConfig);

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = new { user, token = tokencreado } });
            }
            catch (System.Exception)
            {
                throw;
            }

        }


        [HttpPost]
        [Route("ValidarRuta")]
        public IActionResult ValidarRuta([FromBody] AuthUser request)
        {
            var user = null as VwUsuarioDetalles;
            try
            {
                user = _context.VwUsuarioDetalles.FirstOrDefault(obj => obj.Nombre == request.Nombre && obj.Rol == request.Rol);
                if (user == null)
                {
                    // El usuario no fue encontrado, asignar un valor indicativo
                    user = "Usuario no encontrado";
                    return StatusCode(StatusCodes.Status401Unauthorized, new { user });
                }
                else
                {
                }
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "", user });
            }
            catch (System.Exception)
            {
                throw;
            }

        }

    }
}
