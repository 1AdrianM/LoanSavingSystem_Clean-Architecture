using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clientes.Command.Delete
{
    public record DeleteClientCommand(int ClientId):IRequest;
}
