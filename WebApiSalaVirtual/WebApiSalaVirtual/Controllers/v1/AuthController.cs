using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

                // Convierte la clave secreta en un array de bytes utilizando codificación ASCII
                var keyBytes = Encoding.ASCII.GetBytes(secretKey);

                // Crea un objeto ClaimsIdentity que contendrá las reclamaciones asociadas al usuario
                var claims = new ClaimsIdentity();

                // Agrega una reclamación al objeto ClaimsIdentity (en este caso, el nombre del usuario)
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.Nombre));

                // Crea un descriptor de token de seguridad con la información necesaria
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims, // Asigna el objeto ClaimsIdentity al descriptor
                    Expires = DateTime.UtcNow.AddMinutes(480), // Establece la fecha de expiración del token
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature) // Asigna las credenciales de firma usando la clave secreta
                };

                // Crea un manejador de tokens JWT
                var tokenHandler = new JwtSecurityTokenHandler();

                // Crea un token JWT utilizando el descriptor de token de seguridad
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                // Convierte el token JWT en una cadena
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
