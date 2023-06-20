using System.Text;
using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.Configure<GuruDatabaseSettings>(
    builder.Configuration.GetSection("GuruDatabase"));

builder.Services.Configure<KelassDatabaseSettings>(
builder.Configuration.GetSection("KelassDatabase"));

builder.Services.Configure<MapelDatabaseSettings>(
builder.Configuration.GetSection("MapelDatabase"));

builder.Services.Configure<PresensiHarianGuruuDatabaseSettings>(
builder.Configuration.GetSection("PresensiHarianGuruuDatabase"));

builder.Services.AddSingleton<GuruService>();
builder.Services.AddSingleton<KelassService>();
builder.Services.AddSingleton<MapelService>();
builder.Services.AddSingleton<PresensiHarianGuruuService>();

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
}); builder.Services.AddAuthorization();// Add configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Sekolah API",
        Description = "An ASP.NET Core Web API for managing school items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Jeevallucas Gautama",
            Url = new Uri("https://www.linkedin.com/in/jeevallucas")
        },
        License = new OpenApiLicense
        {
            Name = "Jeevallucas Gautama License",
            Url = new Uri("https://example.com/license")
        }
    });

});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthorization();
IConfiguration configuration = app.Configuration;
IWebHostEnvironment environment = app.Environment;
app.MapControllers();
app.Run();