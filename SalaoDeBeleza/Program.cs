using Serilog;
using Microsoft.EntityFrameworkCore;
using SalaoDeBeleza.DataBase;

Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File(
        path: "logs/log-.txt",
        rollingInterval: RollingInterval.Day,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
    ).MinimumLevel.Debug().CreateLogger();


Log.Information("Iniciando a aplicação.");
try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddDbContext<DBContextInMemory>(options =>
    options.UseInMemoryDatabase("salaodebeleza"));
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc(
        "v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Salão de Beleza", Version = "v1" });
    });

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Salão de Beleza");
            c.RoutePrefix = string.Empty;
        });
    }

    app.UseAuthorization();
    app.MapControllers();
    app.Run();

    Log.Information("Aplicação iniciado com sucesso.");
}
catch (Exception ex)
{
    Log.Information("Erro ao inciar a aplicação. Motivo: " + ex.Message);
}
finally
{
    Log.CloseAndFlush();
}