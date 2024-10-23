using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Prestamos.Query.Get
{
  public record PrestamoResponse
    (
          int PrestamoId,  

     int PrestatarioId,   
      
      int? FiadorId,  

     int? Garantia,  

 string CodigoPrestamo, 
 
      DateTime FechaSolicitud,  

      DateTime? FechaAprobacion,  

      DateTime? FechaInicio,  

    DateTime? FechaTermino , 
     decimal? Monto, 

     decimal? Interes  ):IRequest;
    
}
