using WebApiSalaVirtual.Models.Auth;

namespace WebApiSalaVirtual.Services
{
    public interface IAutorizacionService
    {
        Task<AuthReponse> DevolverToken(AuthUser autorizacion);
        Task<AuthReponse> DevolverRefreshToken(RefreshTokenRequest refreshTokenRequest, int UsuarioID);
    }
}