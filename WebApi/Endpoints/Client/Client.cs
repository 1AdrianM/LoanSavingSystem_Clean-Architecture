using Application.Clientes.Command.Create;
using Application.Clientes.Command.Delete;
using Application.Clientes.Command.Update;
using Application.Clientes.Query.Get;
using Application.Clientes.Query.GetAllClient;
using Carter;
using Domain.Entities.Cliente;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApi.Endpoints.Client
{
    public class Client : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var api = app.MapGroup("api/clients/");

            api.MapGet("/health", () => Results.Ok(new { Status = "Healthy", Timestamp = DateTime.UtcNow }));

            api.MapPost("create", async (CreateClientCommand command, ISender sender) =>
            {
                if (sender == null)
                {
                    Console.WriteLine(sender);
                    Log.Information("ISender is null. MediatR might not be configured correctly.");
                    return Results.Problem("ISender not configured correctly.");
                }

                try
                {
                    Console.WriteLine("Sending request POST");
                    Console.WriteLine(command);

                    if (command == null)
                    {
                        return Results.BadRequest("Invalid client data.");
                    }

                    Console.WriteLine("Sending command to MediatR");
                    await sender.Send(command);
                    Console.WriteLine("Command sent successfully");

                    return Results.Ok("Cliente Creado");
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine($"ArgumentNullException: {ex.Message}");
                    return Results.BadRequest($"Argument error: {ex.Message}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"InvalidOperationException: {ex.Message}");
                    return Results.StatusCode(500);
                }
                catch (Exception ex)
                {
                    // Manejo de excepción genérico para cualquier error no específico
                    Console.WriteLine($"Exception: {ex.Message} - StackTrace: {ex.StackTrace}");
                    return Results.StatusCode(500);
                }

            });
            api.MapGet("get/{id:int}", async (int id, ISender sender) =>
            {
                Console.WriteLine("Sending request GET");

                try
                {

                    return Results.Ok(await sender.Send(new GetClientQuery(id)));
                }
                catch (ClientNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    return Results.NotFound(e.Message);

                }
            }); 
         
            api.MapDelete("delete/{id:int}", async (int id, ISender sender) =>
            {
                Console.WriteLine("Sending request DELETE");

                try
                {
                    await sender.Send(new DeleteClientCommand(id));
                    return Results.NoContent();
                }
                catch (ClientNotFoundException e)
                {

                    return Results.NotFound(e.Message);
                }
            });
            api.MapPut("update/{id:int}", async (int id, [FromBody]UpdateClientRequest req, ISender sender) =>
            {

                try
                {
                    var command = new UpdateClientCommand(
                        id,
                        req.Cedula,
                        req.Nombre,
                        req.Apellidos
                        ,req.Email
                        ,req.Telefono
                        ,req.TipoCliente,
                        req.Street,
                        req.City,
                        req.State,
                        req.Country
                        );
                    await sender.Send(command);
                    return Results.Ok();
                }
                catch (ClientNotFoundException e)
                {

                    return Results.NotFound(e.Message);
                }
            });
            api.MapGet("get/clientlist", async ( ISender sender) =>
            {
                Console.WriteLine("Sending request GET");

                try
                {
                   ;
                    return Results.Ok( await sender.Send(new GetAllClientQuery ()));
                }
                catch (ClientNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    return Results.NotFound(e.Message);

                }
            });
        }
    }
}
