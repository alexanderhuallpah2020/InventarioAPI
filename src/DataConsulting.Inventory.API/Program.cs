using DataConsulting.Inventory.Application;
using DataConsulting.Inventory.Persistence;
using DataConsulting.Inventory.External;

var builder = WebApplication.CreateBuilder(args);


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

app.MapControllers();
app.Run();
