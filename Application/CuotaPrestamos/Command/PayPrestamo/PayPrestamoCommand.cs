using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CuotaPrestamos.Command.PayPrestamo
{
    public record PayPrestamoCommand(
        int CuotaId,
        DateTime? fechaEfectiva, string? TipoModalidad
        ) :IRequest;

    public record PayPrestamoRequest(
     DateTime? fechaEfectiva, string? TipoModalidad
     );


}

