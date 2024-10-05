using Domain.Entities.Cliente;
using MediatR;
using Application.SeedOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clientes.Command.Delete
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand>
    {

        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteClientCommandHandler(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;

    }
    public async Task Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
           
            var cliente = await _clienteRepository.GetClientById(request.ClientId);

            if (cliente != null)
            {
         _clienteRepository.Delete(cliente);
            await _unitOfWork.CompletedAsync(cancellationToken);
            }
            

        }
    }
}
