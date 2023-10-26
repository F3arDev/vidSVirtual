using System;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace WebApiSalaVirtual.Models
{
    public class VwSolicitudDetalles
    {
        public int? SolicitudID { get; set; }
        public int? SolicitanteID { get; set; }
        public string? SolicitanteNombre { get; set; }
        [JsonConverter(typeof(JsonDateFormatConverter))]
        public DateTime FechaRegistro { get; set; }
        [JsonConverter(typeof(JsonDateFormatConverter))]
        public DateTime FechaInicio { get; set; }
        [JsonConverter(typeof(JsonDateFormatConverter))]
        public DateTime FechaFin { get; set; }  
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int? VwDepMunicipioID { get; set; }
        public string? Departamento { get; set; }
        public string? Municipio { get; set; }
        public int? EntidadID { get; set; }
        public string? Entidad { get; set; }
        public string? Expediente { get; set; }
        public string? Actividad { get; set; }
        public string? UrlSesion { get; set; }
        public string? Motivo { get; set; }
        public int? EstadoSolicitudID { get; set; }
        public string? EstadoSolicitud { get; set; }
        public int? EstadoRegistroID { get; set; }
        public string? EstadoRegistro { get; set; }
    }

    public class JsonDateFormatConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
        }
    }
}
