using System;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace WebApiSalaVirtual.Models
{
	public class VwUsuarioDetalles
	{
		public int UsuarioID { get; set; }
		public string? Nombre { get; set; }
		public int? RolId { get; set; }
		public string? Rol { get; set; }

		public static implicit operator VwUsuarioDetalles(string v)
		{
			throw new NotImplementedException();
		}
	}
}
