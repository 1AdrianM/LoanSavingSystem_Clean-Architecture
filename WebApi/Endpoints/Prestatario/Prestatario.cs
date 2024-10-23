using Application.Prestatario.Query;
using Carter;
using MediatR;
using Serilog;

namespace WebApi.Endpoints.NewFolder
{
    public class Prestatario : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {

            var api = app.MapGroup("api/v1/prestatario/").WithTags("Prestatario");

            api.MapGet("prestatarioList", async (ISender sender) =>
            {
                try
                {
                    Log.Information("sending prestatario list");
                   return Results.Ok(await sender.Send(new GetAllPrestatarioQuery()));
                }catch(Exception e)
                {
                    Log.Error(e.Message);
                    return Results.BadRequest(e.Message);
                }
            });

        }
    }
}
