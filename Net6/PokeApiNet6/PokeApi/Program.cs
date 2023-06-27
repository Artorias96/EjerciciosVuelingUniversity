using Business.ServiceContracts;
using Business.ServiceImplementations;
using Domain.RepositoryContracts;
using Infrastructure.RepositoryImplementations;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache(memoryCacheOptions => memoryCacheOptions.SizeLimit = 1024);
builder.Logging.ClearProviders();
builder.Services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});
var logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();
builder.Logging.AddSerilog(logger);

builder.Services.AddScoped<IPokeTypesRepository, PokeTypesRepository>();
builder.Services.AddScoped<IPokeMovesRepository, PokeMovesRepository>();
builder.Services.AddScoped<IPokeTypeFyreRepository, PokeTypeFyreRepository>();
builder.Services.AddScoped<IPokeService, PokeService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
