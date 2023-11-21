using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApiSalaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbSalasVirtualesContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL")));

//configuracion de ApiVersion
builder.Services.AddApiVersioning(opt =>
{
    opt.DefaultApiVersion = new ApiVersion(1, 0);
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.ReportApiVersions = true;
    opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                    new HeaderApiVersionReader("x-api-version"),
                                                    new MediaTypeApiVersionReader("x-api-version"));
});

//Configuracion de documentacion Swagger
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

// Add ApiExplorer to discover versions
builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});

var misReglasCors = "ReglasCors";
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: misReglasCors, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });

});

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});


// Agregar la configuración de la aplicación desde el archivo appsettings.json
builder.Configuration.AddJsonFile("appsettings.json");

// Obtener la clave secreta para firmar y verificar los JWT desde la sección "settings" en appsettings.json
var secretKey = builder.Configuration.GetSection("settings").GetSection("secretKey").ToString();

// Convertir la clave secreta a bytes, ya que la SymmetricSecurityKey requiere un array de bytes
var keyBytes = Encoding.UTF8.GetBytes(secretKey);

// Configurar la autenticación en el servicio de la aplicación
builder.Services.AddAuthentication(config =>
{
    // Establecer el esquema de autenticación predeterminado para la autenticación con JWT
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    // Configuración del proveedor de autenticación JWT Bearer

    // Deshabilitar la validación HTTPS para desarrollo (puede ser configurado de manera diferente en producción)
    config.RequireHttpsMetadata = false;

    // Indicar si se debe guardar el token en el contexto de la aplicación
    config.SaveToken = false;

    // Configurar los parámetros de validación del token
    config.TokenValidationParameters = new TokenValidationParameters
    {
        // Habilitar la validación de la clave de firma
        ValidateIssuerSigningKey = true,

        // Establecer la clave de firma utilizada para validar el token
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),

        // Deshabilitar la validación del emisor (issuer) del token
        ValidateIssuer = false,

        // Deshabilitar la validación del destinatario (audience) del token
        ValidateAudience = false
    };
});


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseAuthorization();
app.UseCors(misReglasCors);
app.MapControllers();

app.Run();
