﻿using Application;
using Carter;
using Domain;
using Infrastructure;
using LoanSavingSystem.API.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog;
using System.Reflection;
//using WebApi.Extension;
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

builder.Logging.AddConsole();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCarter();

var app = builder.Build();
// Configurar Serilog


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.RoutePrefix = string.Empty;

        

        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
   }) ;
    
}
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request Path: {context.Request.Path}"); // Log cada vez que se reciba una solicitud
    await next();
});

app.UseCors("AllowAll");

app.UseMiddleware<ExceptionMiddleware>(); // Middleware personalizado

app.UseRouting();

app.UseHttpsRedirection();
Console.WriteLine("Corriendo app");



app.MapCarter();
app.Run();