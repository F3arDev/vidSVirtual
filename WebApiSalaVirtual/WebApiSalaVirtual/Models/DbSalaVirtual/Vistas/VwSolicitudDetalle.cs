using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApiSalaVirtual.Models.DbSalaVirtual.Vistas;

public partial class VwSolicitudDetalles
{
    public int SolicitudId { get; set; }

    public int SolicitanteId { get; set; }

    public string SolicitanteNombre { get; set; } = null!;
    [JsonConverter(typeof(JsonDateFormatConverter))]
    public DateTime FechaRegistro { get; set; }
    [JsonConverter(typeof(JsonDateFormatConverter))]
    public DateTime FechaInicio { get; set; }
    [JsonConverter(typeof(JsonDateFormatConverter))]
    public DateTime FechaFin { get; set; }

    public TimeSpan HoraInicio { get; set; }

    public TimeSpan HoraFin { get; set; }

    public string? Departamento { get; set; }

    public int EntidadId { get; set; }

    public string Entidad { get; set; } = null!;

    public string Expediente { get; set; } = null!;

    public string Actividad { get; set; } = null!;

    public string UrlSesion { get; set; } = null!;

    public string Motivo { get; set; } = null!;

    public int EstadoSolicitudId { get; set; }

    public string EstadoSolicitud { get; set; } = null!;

    public int EstadoRegistroId { get; set; }

    public string EstadoRegistro { get; set; } = null!;
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
