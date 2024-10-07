using Application.SeedOfWork;
using Domain.Entities.Cliente;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clientes.Query.Get
{
    internal class GetClientQueryHandler : IRequestHandler<GetClientQuery, ClientReponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClienteRepository _clienteRepository;
        public GetClientQueryHandler(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;

        }

        public async Task<ClientReponse> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Handling GetClientQuery Request");

            var client = await _clienteRepository.GetClientById(request.ClientId);
            Console.WriteLine("Query Executed. Checking if client is null.");

          
            var clientL = new ClientReponse (client.ClientId, client.Cedula, client.Nombre, client.Apellidos,client.Email,client.Telefono, client.TipoCliente, client.Direccion ) ;
            return clientL;
        }
    }
}
