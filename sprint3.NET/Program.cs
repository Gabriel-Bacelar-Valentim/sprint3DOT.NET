using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using sprint3.NET.Configuration;
using sprint3.NET.Database.Persistencia;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
APIConfiguration apiConfiguration = new();
configuration.Bind(apiConfiguration);
builder.Services.Configure<APIConfiguration>(configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = $"{apiConfiguration.Swagger.Title} {DateTime.Now.Year} ",
        Version = "v1",
        Description = apiConfiguration.Swagger.Description,
        Contact = new OpenApiContact
        {
            Name = apiConfiguration.Swagger.Name,
            Email = apiConfiguration.Swagger.Email
        }
    });
});

builder.Services.AddDbContext<FIAPDbContext>(options =>
{
    options.UseOracle(apiConfiguration.OracleFIAP.ConnectionString);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
