using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Garantia.Query.GetAll
{
    public record GarantiaResponse
   (int GarantiaId,

     string TipoGarantia,

     decimal? Valor,

    string Ubicacion
        );
}
