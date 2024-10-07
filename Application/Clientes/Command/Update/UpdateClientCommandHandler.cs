using Application.SeedOfWork;
using Domain.Entities.Cliente;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clientes.Command.Update
{
    internal class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateClientCommandHandler(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {      var client = await _clienteRepository.GetClientById(request.id);
        
            var direccion = new Direccion(request.Street, request.City, request.State, request.Country);
               client.Update(request.Cedula,
                   request.Nombre,
                   request.Apellidos,
                   request.Email, 
                   request.Telefono, 
                   request.TipoCliente,
                   direccion);
         
            _clienteRepository.Update(client);

            await _unitOfWork.CompletedAsync(cancellationToken);
     
        }

        
    }
}
