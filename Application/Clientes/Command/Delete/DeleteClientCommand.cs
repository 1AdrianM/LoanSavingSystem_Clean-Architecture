using MediatR;
 

namespace Application.Clientes.Command.Delete
{
    public record DeleteClientCommand(int Id):IRequest;
}
