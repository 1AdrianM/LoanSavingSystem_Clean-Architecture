using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Garantia.Query.GetById
{
    public record GarantiaIdResponse(
        int GarantiaId,

     string TipoGarantia,

     decimal? Valor,

    string Ubicacion);
    
    
}
