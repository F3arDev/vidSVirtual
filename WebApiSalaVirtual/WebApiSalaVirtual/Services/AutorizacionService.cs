using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using System.Text;


using WebApiSalaVirtual.Models.Auth;

using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using WebApiSalaVirtual.Models.DbSalaVirtual.Vistas;
using WebApiSalaVirtual.Models.Data;

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

        private string GenerarToken(string UsuarioID)
        {
            var key = _configuration.GetValue<string>("JwtSettings:key");
            var keyBytes = Encoding.ASCII.GetBytes(key);
            // Crea un objeto ClaimsIdentity que contendrá las reclamaciones asociadas al usuario
            var claims = new ClaimsIdentity();
            // Agrega una reclamación al objeto ClaimsIdentity (en este caso, el nombre del usuario)
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, UsuarioID));
            // Crea un descriptor de token de seguridad con la información necesaria
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims, // Asigna el objeto ClaimsIdentity al descriptor
                Expires = DateTime.UtcNow.AddMinutes(120), // Establece la fecha de expiración del token
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

        private static string GenerarRefreshToken()
        {
            var byteArray = new byte[64];
            var refreshToken = "";
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(byteArray);
                refreshToken = Convert.ToBase64String(byteArray);
            }
            return refreshToken;
        }

        private async Task<AuthReponse> GuardarLogRefreshToken(int UsuarioID, string Token, string RefreshToken)
        {
            try
            {
                var LogRefreshToken = new Models.DbSalaVirtual.LogRefreshToken
                {
                    UsuarioId = UsuarioID,
                    Token = Token,
                    RefreshToken = RefreshToken,
                    // FechaCreacion = DateTime.Now,
                    // FechaExpiracion = DateTime.Now.AddMinutes(2)
                };

                await _context.LogRefreshToken.AddAsync(LogRefreshToken);
                await _context.SaveChangesAsync();

                return new AuthReponse { Token = Token, RefreshToken = RefreshToken };
            }
            catch (System.Exception)
            {

                throw;
            }
        }


        public async Task<object> DevolverToken(AuthUser autorizacion)
        {
            try
            {
                var usuario = null as VwUsuarioDetalles;
                usuario = _context.VwUsuarioDetalles.FirstOrDefault(obj => obj.Nombre == autorizacion.Nombre && obj.Rol == autorizacion.Rol);
                if (usuario == null)
                {
                    return await Task.FromResult<object>(null);
                }
                string Token = GenerarToken(usuario.UsuarioId.ToString());
                string RefreshToken = GenerarRefreshToken();
                var Tokens = await GuardarLogRefreshToken(usuario.UsuarioId, Token, RefreshToken);
                return new { usuario, Tokens };
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<AuthReponse> DevolverRefreshToken(RefreshTokenRequest refreshTokenRequest, int UsuarioID)
        {
            var refreshTokenEncontrado = _context.LogRefreshToken.FirstOrDefault(x =>
            x.Token == refreshTokenRequest.TokenExpirado &&
            x.RefreshToken == refreshTokenRequest.RefreshToken &&
            x.UsuarioId == UsuarioID
            );

            if (refreshTokenEncontrado == null)
            {
                return new AuthReponse { Token = "null", RefreshToken = "null" };
            }


            var RefreshToken = GenerarRefreshToken();
            var Token = GenerarToken(UsuarioID.ToString());

            return await GuardarLogRefreshToken(UsuarioID, Token, RefreshToken);
        }

    }
}