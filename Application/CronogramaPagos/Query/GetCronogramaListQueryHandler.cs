using Domain.Entities.Prestamo;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CronogramaPagos.Query
{
    internal class GetCronogramaListQueryHandler : IRequestHandler<GetCronogramaListQuery, List<CronogramaResponse>>
    {
        private readonly IPrestamo _prestamo;

        public GetCronogramaListQueryHandler(IPrestamo prestamo)
        {
            _prestamo = prestamo;
        }
        public async Task<List<CronogramaResponse>> Handle(GetCronogramaListQuery request, CancellationToken cancellationToken)
        {
            var prestamo =  await _prestamo.GetPrestamoByCodigoPrestamo(request.id.ToString());
             var lista = _prestamo.GenerarCronogramaPagos(prestamo);
            return lista.Select(p=> new CronogramaResponse(p.Fecha_Plazo, p.Monto)).ToList();
        }
    }
}
