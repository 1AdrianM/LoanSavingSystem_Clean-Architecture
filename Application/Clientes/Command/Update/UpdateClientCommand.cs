using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clientes.Command.Update
{
    public record UpdateClientCommand(
    int id,
    string Cedula,
    string Nombre,
    string Apellidos,
    string Email,
    string Telefono,
    string TipoCliente,
    string Street,
    string City,
    string State,
    string Country):IRequest;

    public record UpdateClientRequest(
 
    string Cedula,
    string Nombre,
    string Apellidos,
    string Email,

    string Telefono,
    string TipoCliente,
    string Street,
   string City,
    string State,
    string Country);
}
