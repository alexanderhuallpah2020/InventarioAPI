using DataConsulting.Inventory.Application;
using DataConsulting.Inventory.Persistence;
using DataConsulting.Inventory.External;
using DataConsulting.Inventory.API.Extensions;
using DataConsulting.Inventory.API.Middleware;
using Microsoft.AspNetCore.Http.Features;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCustomExceptionHandling(); // Middleware de manejo de excepciones

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Inyeccion de dependencias por capas
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddExternal();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseExceptionHandler(); // Middleware de manejo de excepciones


app.ApplyMigration();
app.MapControllers();
app.Run();
