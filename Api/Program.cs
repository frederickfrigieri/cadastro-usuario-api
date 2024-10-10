using Api;
using Api.Endpoints;
using Application;
using Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();

builder.Services.RegisterApplicationDI();
builder.Services.RegisterInfrastructureDI(builder.Configuration);
builder.Services.RegisterApiDI();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.RegisterUsuarioEndpoint();

app.Run();

public partial class Program { }