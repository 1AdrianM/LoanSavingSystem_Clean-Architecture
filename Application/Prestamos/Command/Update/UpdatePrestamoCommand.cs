using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Prestamos.Command.Update
{
   public record UpdatePrestamoCommand(
           int PrestamoId,

     int PrestatarioId,

      int? FiadorId,

     int? Garantia,

 string CodigoPrestamo,

      DateTime FechaSolicitud,

      DateTime? FechaAprobacion,

      DateTime? FechaInicio,

    DateTime? FechaTermino,
     decimal? Monto,

     decimal? Interes

       ) :IRequest;
    public record UpdatePrestamoRequest(

            int PrestamoId,

     int PrestatarioId,

      int? FiadorId,

     int? Garantia,

 string CodigoPrestamo,

      DateTime FechaSolicitud,

      DateTime? FechaAprobacion,

      DateTime? FechaInicio,

    DateTime? FechaTermino,
     decimal? Monto,

     decimal? Interes


        );

}
