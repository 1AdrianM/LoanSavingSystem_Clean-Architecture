using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Prestamo
{
    public record Cronograma_Pagos(
         DateTime Fecha_Plazo,
        decimal Monto);
    
    
}
