using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using System.Text;


using WebApiSalaVirtual.Models.Auth;
using WebApiSalaVirtual.Models;

using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;


namespace WebApiSalaVirtual.Services
{
    public class AutorizacionService : IAutorizacionService
    {
        private readonly DbSalasVirtualesContext _context;
        private readonly IConfiguration _configuration;

        public AutorizacionService(DbSalasVirtualesContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        private string GenerarToken(string Nombre)
        {

            var key = _configuration.GetValue<string>("JwtSettings:key");

            var keyBytes = Encoding.ASCII.GetBytes(key);

            // Crea un objeto ClaimsIdentity que contendrá las reclamaciones asociadas al usuario
            var claims = new ClaimsIdentity();

            // Agrega una reclamación al objeto ClaimsIdentity (en este caso, el nombre del usuario)
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, Nombre));

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


            return tokencreado;
        }

        public async Task<AuthReponse> DevolverToken(AuthUser autorizacion)
        {
            try
            {
                var user = null as VwUsuarioDetalles;
                user = _context.VwUsuarioDetalles.FirstOrDefault(obj => obj.Nombre == autorizacion.Nombre && obj.Rol == autorizacion.Rol);

                if (user == null)
                {
                    return await Task.FromResult<AuthReponse>(null);
                }

                string Token = GenerarToken("Fredd");
                return new AuthReponse() { Token =  Token, Resultado = true, Msg = "OK" };
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}