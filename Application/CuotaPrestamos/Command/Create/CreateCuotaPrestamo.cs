using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CuotaPrestamos.Command.Create
{
    public record CreateCuotaPrestamoCommand(
            int CuotaId ,
      int PrestamoId ,
      DateTime FechaPlanificada,
     decimal MontoPlanificado,
  string? TipoModalidad):IRequest;
    
    
}
