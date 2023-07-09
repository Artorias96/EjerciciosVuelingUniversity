using Contracts.DomainEntitites;
using Contracts.RepositoryContracts;
using Contracts.ServiceContracts;
using Implementations;
using InfrastructureData.RepositoryImplementations;
using Microsoft.Extensions.Caching.Memory;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMemoryCache(memoryCacheOptions =>
{
    //memoryCacheOptions.SizeLimit = 1024;
    memoryCacheOptions.ExpirationScanFrequency = TimeSpan.FromMinutes(3);
    MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(6),
        SlidingExpiration = TimeSpan.FromMinutes(1.5)
    };
});

builder.Logging.ClearProviders();

var logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();

builder.Logging.AddSerilog(logger);

builder.Services.AddScoped<IRecetasCocinaService, RecetasCocinaService>();
builder.Services.AddScoped<IAlimentosRepository, AlimentosRepository>();
builder.Services.AddScoped<IRecetasRepository, RecetasRepository>();
builder.Services.AddScoped<IPrecioCocinadoRepository, PrecioCocinadoRepository>();
builder.Services.AddScoped<ICacheRepository, CacheRepository>();

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

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
