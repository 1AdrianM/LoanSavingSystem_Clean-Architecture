using Application.CuotaPrestamos.Command.Create;
using Application.CuotaPrestamos.Command.PayPrestamo;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints.CuotaPrestamo
{
    public class CuotaPrestamo : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var api = app.MapGroup("api/v1/cuotaPrestamo/").WithTags("Cuota de Prestamo");
            api.MapPost("create/draft", async (CreateCuotaPrestamoCommand command, ISender sender) =>
            {
                await sender.Send(command);
                return Results.Ok("Creando Cuota");
            });
            api.MapPatch("pay/{id:int}", async(int id,[FromBody]PayPrestamoRequest req, ISender sender) => {

                var command = new PayPrestamoCommand(
                    id, req.fechaEfectiva, req.TipoModalidad);
                await sender.Send(command);
                return Results.Ok("Cuota realizada");
            
            
            
            
            });

        }
    }
}
