using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Fiador
{
    public record Fiador(
          int FiadorId,
          int ClientId,
         string Estado
        );


}
