using Application.SeedOfWork;
using Domain.Entities.CuotaPrestamo;
using Domain.Entities.Prestamo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CuotaPrestamos.Command.PayPrestamo
{
    internal class PayPrestamoCommandHandler : IRequestHandler <PayPrestamoCommand>
    {
        private readonly ICuotaPrestamo _cuota;
        private readonly IUnitOfWork _unitOfWork;
      
        public PayPrestamoCommandHandler(ICuotaPrestamo cuota, IUnitOfWork unitOfWork )
        {
            _cuota = cuota;
            _unitOfWork = unitOfWork;
         }
        
            
        
        public async Task Handle(PayPrestamoCommand request, CancellationToken cancellationToken)
        {
            var cuota = await _cuota.GetByIdCuotasPrestamo(request.CuotaId);
             cuota.PagoCuota(request.fechaEfectiva,request.TipoModalidad, Guid.NewGuid().ToString(), "");
            _cuota.PagarCuota(cuota);
           await _unitOfWork.CompletedAsync(cancellationToken);


         }
    }
}
