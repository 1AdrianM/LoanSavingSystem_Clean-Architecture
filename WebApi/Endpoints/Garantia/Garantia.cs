using Application.Clientes.Command.Delete;
using Application.Garantia.Command.Create;
using Application.Garantia.Command.Delete;
using Application.Garantia.Query.GetAll;
using Application.Garantia.Query.GetById;
using Application.Prestamos.Command.Create;
using Carter;
using MediatR;
using Serilog;

namespace WebApi.Endpoints.Garantia
{
    public class Garantia : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var api = app.MapGroup("api/v1/garantias").WithTags("Garantia");


            api.MapPost("create", async (CreateGarantiaCommand command, ISender sender) => {


                try
                {
                    await sender.Send(command);
                    Log.Information("Sending command at POST API");

                    return Results.Ok("Garantia Creado");
                }
                catch (Exception e)
                {
                    Log.Error(e.Message);
                    return Results.BadRequest(e.Message);
                }

            }
            );

            api.MapDelete("delete/{id:int}", async (int id, ISender sender) =>
            {
                try
                {
                    await sender.Send(new DeleteGarantiaCommand(id));
                    Log.Information("Garantia Deleted");
                    return Results.NoContent();
                }
                catch (Exception e)
                {
                    Log.Error(e.Message);
                    return Results.BadRequest(e.Message);
                }
            });
            api.MapGet("get/garantias", async ( ISender sender) =>
            {
                try
                {
                    ;
                    return Results.Ok(await sender.Send(new GetAllGarantiaQuery()));
                }
                catch (Exception e)
                {
                    Log.Error(e.Message);
                    return Results.NotFound(e.Message);
                }
            });

            api.MapGet("get/{id:int}", async (int id , ISender sender) =>
            {

                try {



                    return Results.Ok(await sender.Send(new GetGarantiaByQuery(id)));
                
                
                }catch(Exception e)
                {
                    Log.Error(e.Message);
                    return Results.NoContent();
                }

            });
        }
    }
}
