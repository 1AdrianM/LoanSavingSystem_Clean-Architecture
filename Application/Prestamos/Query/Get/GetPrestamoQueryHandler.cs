using Domain.Entities.Prestamo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Prestamos.Query.Get
{
    internal class GetPrestamoQueryHandler : IRequestHandler<GetPrestamoQuery, List<PrestamoResponse>>
    {
        private readonly IPrestamo _prestamo;
        public GetPrestamoQueryHandler(IPrestamo prestamo)
        {
            _prestamo = prestamo;
        }
        public async Task<List<PrestamoResponse>> Handle(GetPrestamoQuery request, CancellationToken cancellationToken)
        {
          var prestamoList =  await _prestamo.GetAllPrestamos();
          return prestamoList.Select(p => new PrestamoResponse(p.PrestamoId, p.PrestatarioId,p.FiadorId, p.Garantia, p.CodigoPrestamo, p.FechaSolicitud, p.FechaAprobacion, p.FechaInicio, p.FechaTermino, p.Monto, p.Interes)).ToList();
        }
    }
}
