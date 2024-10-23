using Domain.Entities.Cliente;
using MediatR;
using Application.SeedOfWork;
 

namespace Application.Clientes.Command.Delete
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand>
    {

        private readonly ICliente _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteClientCommandHandler(ICliente clienteRepository, IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;

    }
    public async Task Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
           
            var cliente = await _clienteRepository.GetClientById(request.Id);
            
                 _clienteRepository.Delete(cliente);
            await _unitOfWork.CompletedAsync(cancellationToken);
            
            

        }
    }
}
