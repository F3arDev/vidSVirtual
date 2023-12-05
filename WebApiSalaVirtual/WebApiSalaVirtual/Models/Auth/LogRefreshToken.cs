namespace WebApiSalaVirtual.Models.Auth
{
	public class LogRefreshToken
	{
		public int LogRefreshTokenID { get; set; }
		public int UsuarioID { get; set; }
		public string Token { get; set; } = null!;
		public string RefreshToken { get; set; } = null!;
		public DateTime FechaCreacion { get; set; }
		public DateTime FechaExpiracion { get; set; }
		public int Estado { get; set; }
	}
}