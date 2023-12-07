namespace WebApiSalaVirtual.Models.Auth
{
    public class AuthReponse
    {
        public string Token { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
        // public bool? Resultado { get; set; }
        // public string Msg { get; set; } = null!;
    }
}