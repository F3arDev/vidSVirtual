namespace WebApiSalaVirtual.Models.Auth.VwAuth
{
	public class VwRolesRutas
	{
		public int UsuarioRolID { get; set; }
		public string Rol { get; set; } = null!;
		public int RutaID { get; set; }
		public string NombreRuta { get; set; } = null!;
	}
}
