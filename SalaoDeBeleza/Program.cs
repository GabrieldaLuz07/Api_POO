using Microsoft.EntityFrameworkCore;
using SalaoDeBeleza.Classes;
using SalaoDeBeleza.Components;
using SalaoDeBeleza.DataBase;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<SchedulingComponent>();
builder.Services.AddScoped<ProfessionalComponent>();
builder.Services.AddScoped<CustomerComponent>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DBContextInMemory>(options => options.UseInMemoryDatabase("salaodebeleza"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
