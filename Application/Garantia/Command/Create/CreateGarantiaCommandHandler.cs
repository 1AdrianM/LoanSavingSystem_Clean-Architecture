using Application.SeedOfWork;
 using Domain.Entities.Garantia;

using Domain.Entities.Prestamo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Garantia.Command.Create
{
    internal class CreateGarantiaCommandHandler : IRequestHandler<CreateGarantiaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGarantia _garantia;

        public CreateGarantiaCommandHandler(IUnitOfWork unitOfWork, IGarantia garantia)
        {
            _unitOfWork = unitOfWork;
            _garantia = garantia;
        }
        public async Task Handle(CreateGarantiaCommand request, CancellationToken cancellationToken)
        {
            var garantia = new Garantias(request.GarantiaId, request.TipoGarantia, request.Valor, request.Ubicacion);
            _garantia.Add(garantia);
            await _unitOfWork.CompletedAsync(cancellationToken);
        }
    }
}
