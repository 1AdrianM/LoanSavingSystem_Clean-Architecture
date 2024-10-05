using Domain.Entities.Cliente;
using MediatR;

namespace Application.Clientes.Command.Create
{
    public record CreateClientCommand(
    int ClientId,
   string Cedula,
    string Nombre,
    string Apellidos,
    string Email,
 
    string Telefono,
    string TipoCliente,
    string Street,
   string City,
    string State,
    string Country
    ):IRequest;
    

}
   

