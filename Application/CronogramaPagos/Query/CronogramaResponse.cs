using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CronogramaPagos.Query
{
    public record CronogramaResponse(
        DateTime? Fecha_Plazo,
        decimal? Monto
        );
 
   
}
