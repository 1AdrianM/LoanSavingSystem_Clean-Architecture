using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Prestatario.Query
{
    public record PrestatarioResponse(
        int PrestatarioId,
 int? ClientId,
  string? EstadoPrestatario,
int? CantidadPrestamos
        ) : IRequest;


}
