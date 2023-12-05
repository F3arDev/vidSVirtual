namespace WebApiSalaVirtual.Models.Auth
{
	public class RefreshTokenRequest
	{
		public string TokenExpirado { get; set; } = null!;
		public string RefreshToken { get; set; } = null!;
	}
}