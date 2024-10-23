using Application.SeedOfWork;
using Domain.Entities.Prestamo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Prestamos.Command.Approved
{
    internal class ApprovedPrestamoCommandHandler : IRequestHandler<ApprovedPrestamoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPrestamo _prestamo;
        public ApprovedPrestamoCommandHandler(IUnitOfWork unitOfWork, IPrestamo prestamo)
        {
            _unitOfWork = unitOfWork;
            _prestamo = prestamo;

        }
        public async Task Handle(ApprovedPrestamoCommand request, CancellationToken cancellationToken)
        {
          var prestamo = await _prestamo.GetPrestamoByCodigoPrestamo(request.id);

              prestamo.AprobarPrestamo();
            
            _prestamo.AprobarPrestamo(prestamo);
              
            await _unitOfWork.CompletedAsync(cancellationToken);
        }
    }
}
