using System;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace WebApiSalaVirtual.Models
{
	public class VwUsuarioDetalles
	{
		public int? UsuarioID { get; set; }
		public string? Nombre { get; set; }
		public string? Rol { get; set; }
	}
}
