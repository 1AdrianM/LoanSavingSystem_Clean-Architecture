using Application.Clientes.Command.Delete;
using Application.CronogramaPagos.Query;
using Application.Prestamos.Command.Approved;
using Application.Prestamos.Command.Create;
using Application.Prestamos.Command.Delete;
using Application.Prestamos.Command.Update;
using Application.Prestamos.Query.Get;
using Carter;
using Domain.Entities.Prestamo;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace WebApi.Endpoints.Prestamo
{
    public class Prestamo : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var api = app.MapGroup("api/v1/prestamos/").WithTags("Prestamos");

            api.MapPost("create", async (CreatePrestamoCommand command, ISender sender) =>
            {

                try {

                    await sender.Send(command);
                    return Results.Ok("Prestamo Creado");

                
                }
                catch(Exception ex) { 
                    Console.WriteLine(ex);
                    throw new Exception(ex.Message);
                
                }


            });
            api.MapPut("put/{id:Guid}", async (Guid id,[FromBody] UpdatePrestamoRequest req, ISender sender) =>
            {
                var command = new UpdatePrestamoCommand(
                    req.PrestamoId,
                    req.PrestatarioId,
                    req.FiadorId,
                    req.Garantia,
                    id.ToString(),
                    req.FechaSolicitud,
                    req.FechaAprobacion,
                    req.FechaInicio,
                    req.FechaTermino,
                    req.Monto,
                    req.Interes
                    );
                await sender.Send(command);
                return Results.Ok();
            });

            api.MapDelete("delete/{id:Guid}", async (Guid id ,ISender sender ) =>
            {
                try
                {
                await sender.Send(new DeletePrestamoCommand(id.ToString()));
                return Results.NoContent();
                
                }
                catch (PrestamoNotFoundException e) 
                 {
                    return Results.NotFound(e.Message);
                    
                } 

            });
            api.MapPatch("approve/{id:Guid}", async(Guid id, ISender sender) =>
            {
                try
                {
                    
                    await sender.Send(new ApprovedPrestamoCommand(id.ToString()));
                    Log.Information("Aprobando prestamo");
                    return Results.Ok("Prestamo Aprobado");
                }
                catch (Exception E) {
                    Log.Error(E.Message);
                    return Results.BadRequest();
                }
                    
                
                }
                        );
            api.MapGet("get/PrestamoList", async (ISender sender) =>
            {
                try
                {
                    Log.Information("Sending GetAllQuery Command");
                    return Results.Ok(await sender.Send(new GetPrestamoQuery()));

                }
                catch (Exception e)
                {
                    Log.Error(e.Message);

                    return Results.BadRequest("Error during retreiving");
                }
            });

            api.MapGet("generate/{id:guid}/Cronograma", async (Guid id,ISender sender) => {

                try
                {
                    Log.Information("Generando Cronograma");
                    return Results.Ok(await sender.Send(new GetCronogramaListQuery(id)));
                
                }
                catch(PrestamoNotFoundException e)
                {
                    Log.Error(e.Message);
                    return Results.BadRequest(e.Message);
                }
                catch(ArgumentNullException e)
                {
                    Log.Error(e.Message);
                    return Results.StatusCode(500);
                }
            
            });
        }
    }
}
