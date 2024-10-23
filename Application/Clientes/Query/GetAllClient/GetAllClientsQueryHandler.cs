using Application.Clientes.Query.Get;
using Application.SeedOfWork;
using Domain.Entities.Cliente;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clientes.Query.GetAllClient
{
    internal class GetAllClientsQueryHandler : IRequestHandler<GetAllClientQuery, List<ClientListResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICliente _clienteRepository;
        public GetAllClientsQueryHandler(ICliente clienteRepository, IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;

        }

        async Task<List<ClientListResponse>> IRequestHandler<GetAllClientQuery, List<ClientListResponse>>.Handle(GetAllClientQuery request, CancellationToken cancellationToken)
        {
            var clientList = await _clienteRepository.GetAll();


            return clientList.Select(p => new ClientListResponse(p.ClientId,
                p.Cedula,
                p.Nombre,
                p.Apellidos,
                p.Email,
                p.TipoCliente,
                p.Direccion,
                p.Telefono
                )).ToList();
              

        }
    }
}
