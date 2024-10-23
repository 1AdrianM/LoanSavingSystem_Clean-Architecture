using Application.SeedOfWork;
using Domain.Entities.Garantia;
using Domain.Entities.Prestamo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Prestamos.Command.Create
{
    internal class CreatePrestamoCommandHandler : IRequestHandler<CreatePrestamoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPrestamo _prestamo;

        public CreatePrestamoCommandHandler(IUnitOfWork unitOfWork, IPrestamo prestamo)
        {
            _unitOfWork = unitOfWork;
            _prestamo = prestamo;
        }

        public async Task Handle(CreatePrestamoCommand request, CancellationToken cancellationToken)
        {
           var codigo = Guid.NewGuid().ToString();
            Console.WriteLine(codigo);
            var prestamo = Prestamo.CreateSolicitud(0,request.PrestatarioId, request.Fiador, request.GarantiaId ,codigo, request.FechaSolicitud, request.Monto, 0);
           _prestamo.CreatePrestamoRequest(prestamo);
            await _unitOfWork.CompletedAsync(cancellationToken);
        }
    }
}
