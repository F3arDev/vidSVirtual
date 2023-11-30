using WebApiSalaVirtual.Models.Auth;

namespace WebApiSalaVirtual.Services
{
    public interface IAutorizacionService
    {

        Task<AuthReponse> DevolverToken(AuthUser autorizacion);
        //Task<AutorizacionResponse> DevolverRefreshToken(RefreshTokenRequest refreshTokenRequest, int idUsuario);
    }
}