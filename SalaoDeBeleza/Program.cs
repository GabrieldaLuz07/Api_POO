using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SalaoDeBeleza.Classes;
using SalaoDeBeleza.DataBase;

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
