using Application.SeedOfWork;
using Domain.Entities.Prestamo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Prestamos.Command.Update
{
    internal class UpdatePrestamoCommandHandler : IRequestHandler<UpdatePrestamoCommand>
    {
        private readonly IPrestamo _prestamo;

        private readonly IUnitOfWork _unitOfWork;
        public UpdatePrestamoCommandHandler(IUnitOfWork unitOfWork, IPrestamo prestamo)
        {
            _unitOfWork = unitOfWork;
            _prestamo = prestamo;
        }

        public async Task Handle(UpdatePrestamoCommand request, CancellationToken cancellationToken)
        {
            var prestamo =await _prestamo.GetPrestamoByCodigoPrestamo(request.CodigoPrestamo);
            prestamo.Update(
                request.PrestamoId,
                request.PrestatarioId,
                request.FiadorId,
                request.Garantia,
                request.CodigoPrestamo,
                request.FechaSolicitud,
                request.FechaInicio,
                request.FechaTermino,
                request.FechaAprobacion,
                request.Monto,
                request.Interes
                );
            _prestamo.Update(prestamo);
            await _unitOfWork.CompletedAsync(cancellationToken);
        }
    }
}
